using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable

namespace Testably.Expectations.Core.Helpers;

/// <summary>
/// Determines which members are included in the equivalency assertion
/// </summary>
[Flags]
internal enum MemberVisibility
{
	None = 0,
	Internal = 1,
	Public = 2,
	ExplicitlyImplemented = 4
}

/// <summary>
/// Helper class to get all the public and internal fields and properties from a type.
/// </summary>
internal sealed class TypeMemberReflector
{
	private const BindingFlags AllInstanceMembersFlag =
		BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

	public TypeMemberReflector(Type typeToReflect, MemberVisibility visibility)
	{
		Properties = LoadProperties(typeToReflect, visibility);
		Fields = LoadFields(typeToReflect, visibility);
		Members = [.. Properties, .. Fields];
	}

	public MemberInfo[] Members { get; }

	public PropertyInfo[] Properties { get; }

	public FieldInfo[] Fields { get; }

	private static PropertyInfo[] LoadProperties(Type typeToReflect, MemberVisibility visibility)
	{
		List<PropertyInfo> query = GetPropertiesFromHierarchy(typeToReflect, visibility);

		return query.ToArray();
	}

	private static List<PropertyInfo> GetPropertiesFromHierarchy(Type typeToReflect, MemberVisibility memberVisibility)
	{
		bool includeInternal = memberVisibility.HasFlag(MemberVisibility.Internal);
		bool includeExplicitlyImplemented = memberVisibility.HasFlag(MemberVisibility.ExplicitlyImplemented);

		return GetMembersFromHierarchy(typeToReflect, type =>
		{
			return
				from p in type.GetProperties(AllInstanceMembersFlag | BindingFlags.DeclaredOnly)
				where p.GetMethod is { } getMethod
					&& (IsPublic(getMethod) || (includeExplicitlyImplemented && IsExplicitlyImplemented(getMethod)))
					&& (includeInternal || !IsInternal(getMethod))
					&& !p.IsIndexer()
				orderby IsExplicitImplementation(p)
				select p;
		});
	}

	private static bool IsPublic(MethodBase getMethod) =>
		!getMethod.IsPrivate && !getMethod.IsFamily && !getMethod.IsFamilyAndAssembly;

	private static bool IsExplicitlyImplemented(MethodBase getMethod) =>
		getMethod.IsPrivate && getMethod.IsFinal;

	private static bool IsInternal(MethodBase getMethod) =>
		getMethod.IsAssembly || getMethod.IsFamilyOrAssembly;

	private static bool IsExplicitImplementation(PropertyInfo property)
	{
		return property.GetMethod!.IsPrivate &&
			property.SetMethod?.IsPrivate != false &&
			property.Name.Contains('.', StringComparison.Ordinal);
	}

	private static FieldInfo[] LoadFields(Type typeToReflect, MemberVisibility visibility)
	{
		List<FieldInfo> query = GetFieldsFromHierarchy(typeToReflect, visibility);

		return query.ToArray();
	}

	private static List<FieldInfo> GetFieldsFromHierarchy(Type typeToReflect, MemberVisibility memberVisibility)
	{
		bool includeInternal = memberVisibility.HasFlag(MemberVisibility.Internal);

		return GetMembersFromHierarchy(typeToReflect, type =>
		{
			return type
				.GetFields(AllInstanceMembersFlag)
				.Where(field => IsPublic(field))
				.Where(field => includeInternal || !IsInternal(field));
		});
	}

	private static bool IsPublic(FieldInfo field) =>
		!field.IsPrivate && !field.IsFamily && !field.IsFamilyAndAssembly;

	private static bool IsInternal(FieldInfo field)
	{
		return field.IsAssembly || field.IsFamilyOrAssembly;
	}

	private static List<TMemberInfo> GetMembersFromHierarchy<TMemberInfo>(
		Type typeToReflect,
		Func<Type, IEnumerable<TMemberInfo>> getMembers)
		where TMemberInfo : MemberInfo
	{
		if (typeToReflect.IsInterface)
		{
			return GetInterfaceMembers(typeToReflect, getMembers);
		}

		return GetClassMembers(typeToReflect, getMembers);
	}

	private static List<TMemberInfo> GetInterfaceMembers<TMemberInfo>(Type typeToReflect,
		Func<Type, IEnumerable<TMemberInfo>> getMembers)
		where TMemberInfo : MemberInfo
	{
		List<TMemberInfo> members = [];

		var considered = new List<Type>();
		var queue = new Queue<Type>();
		considered.Add(typeToReflect);
		queue.Enqueue(typeToReflect);

		while (queue.Count > 0)
		{
			Type subType = queue.Dequeue();

			foreach (Type subInterface in subType.GetInterfaces())
			{
				if (considered.Contains(subInterface))
				{
					continue;
				}

				considered.Add(subInterface);
				queue.Enqueue(subInterface);
			}

			IEnumerable<TMemberInfo> typeMembers = getMembers(subType);

			IEnumerable<TMemberInfo> newPropertyInfos = typeMembers.Where(x => !members.Contains(x));

			members.InsertRange(0, newPropertyInfos);
		}

		return members;
	}

	private static List<TMemberInfo> GetClassMembers<TMemberInfo>(Type typeToReflect,
		Func<Type, IEnumerable<TMemberInfo>> getMembers)
		where TMemberInfo : MemberInfo
	{
		List<TMemberInfo> members = [];

		while (typeToReflect != null)
		{
			foreach (var memberInfo in getMembers(typeToReflect))
			{
				if (members.TrueForAll(mi => mi.Name != memberInfo.Name))
				{
					members.Add(memberInfo);
				}
			}

			typeToReflect = typeToReflect.BaseType;
		}

		return members;
	}
}

internal static class TypeExtensions
{
	private const BindingFlags PublicInstanceMembersFlag =
		BindingFlags.Public | BindingFlags.Instance;

	private const BindingFlags AllStaticAndInstanceMembersFlag =
		PublicInstanceMembersFlag | BindingFlags.NonPublic | BindingFlags.Static;

	private static readonly ConcurrentDictionary<Type, bool> TypeIsRecordCache = new();
	private static readonly ConcurrentDictionary<Type, bool> TypeIsCompilerGeneratedCache = new();

	private static readonly ConcurrentDictionary<(Type Type, MemberVisibility Visibility), TypeMemberReflector>
		TypeMemberReflectorsCache = new();

	public static bool IsDecoratedWith<TAttribute>(this Type type)
		where TAttribute : Attribute
	{
		return type.IsDefined(typeof(TAttribute), inherit: false);
	}

	public static bool IsDecoratedWith<TAttribute>(this MemberInfo type)
		where TAttribute : Attribute
	{
		// Do not use MemberInfo.IsDefined
		// There is an issue with PropertyInfo and EventInfo preventing the inherit option to work.
		// https://github.com/dotnet/runtime/issues/30219
		return Attribute.IsDefined(type, typeof(TAttribute), inherit: false);
	}

	public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this MemberInfo type, bool inherit = false)
		where TAttribute : Attribute
	{
		// Do not use MemberInfo.GetCustomAttributes.
		// There is an issue with PropertyInfo and EventInfo preventing the inherit option to work.
		// https://github.com/dotnet/runtime/issues/30219
		return CustomAttributeExtensions.GetCustomAttributes<TAttribute>(type, inherit);
	}

	public static MemberInfo[] GetMembers(this Type typeToReflect, MemberVisibility visibility)
	{
		return GetTypeReflectorFor(typeToReflect, visibility).Members;
	}

	private static TypeMemberReflector GetTypeReflectorFor(Type typeToReflect, MemberVisibility visibility)
	{
		return TypeMemberReflectorsCache.GetOrAdd((typeToReflect, visibility),
			static key => new TypeMemberReflector(key.Type, key.Visibility));
	}

	public static MethodInfo GetMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
	{
		return type.GetMethods(AllStaticAndInstanceMembersFlag)
			.SingleOrDefault(m =>
				m.Name == methodName && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));
	}

	public static MethodInfo GetParameterlessMethod(this Type type, string methodName)
	{
		return type.GetMethod(methodName, Enumerable.Empty<Type>());
	}

	public static bool IsIndexer(this PropertyInfo member)
	{
		return member.GetIndexParameters().Length != 0;
	}

	public static bool IsCompilerGenerated(this Type type)
	{
		return TypeIsCompilerGeneratedCache.GetOrAdd(type, static t =>
			t.IsRecord() ||
			t.IsAnonymous() ||
			t.IsTuple());
	}

	/// <summary>
	/// Check if the type has a human-readable name.
	/// </summary>
	/// <returns>false for compiler generated type names, otherwise true.</returns>
	public static bool HasFriendlyName(this Type type)
	{
		return !type.IsAnonymous() && !type.IsTuple();
	}

	private static bool IsTuple(this Type type)
	{
		if (!type.IsGenericType)
		{
			return false;
		}

#if !(NET47 || NETSTANDARD2_0)
        return typeof(ITuple).IsAssignableFrom(type);
#else
		Type openType = type.GetGenericTypeDefinition();

		return openType == typeof(ValueTuple<>)
			|| openType == typeof(ValueTuple<,>)
			|| openType == typeof(ValueTuple<,,>)
			|| openType == typeof(ValueTuple<,,,>)
			|| openType == typeof(ValueTuple<,,,,>)
			|| openType == typeof(ValueTuple<,,,,,>)
			|| openType == typeof(ValueTuple<,,,,,,>)
			|| (openType == typeof(ValueTuple<,,,,,,,>) && IsTuple(type.GetGenericArguments()[7]))
			|| openType == typeof(Tuple<>)
			|| openType == typeof(Tuple<,>)
			|| openType == typeof(Tuple<,,>)
			|| openType == typeof(Tuple<,,,>)
			|| openType == typeof(Tuple<,,,,>)
			|| openType == typeof(Tuple<,,,,,>)
			|| openType == typeof(Tuple<,,,,,,>)
			|| (openType == typeof(Tuple<,,,,,,,>) && IsTuple(type.GetGenericArguments()[7]));
#endif
	}

	private static bool IsAnonymous(this Type type)
	{
		bool nameContainsAnonymousType = type?.FullName?.Contains("AnonymousType", StringComparison.Ordinal) == true;

		if (!nameContainsAnonymousType)
		{
			return false;
		}

		bool hasCompilerGeneratedAttribute =
			type.IsDecoratedWith<CompilerGeneratedAttribute>();

		return hasCompilerGeneratedAttribute;
	}

	public static bool IsRecord(this Type type)
	{
		return TypeIsRecordCache.GetOrAdd(type, static t => t.IsRecordClass() || t.IsRecordStruct());
	}

	private static bool IsRecordClass(this Type type)
	{
		return type.GetMethod("<Clone>$", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly) is { } &&
			type.GetProperty("EqualityContract", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)?
				.GetMethod?.IsDecoratedWith<CompilerGeneratedAttribute>() == true;
	}

	private static bool IsRecordStruct(this Type type)
	{
		// As noted here: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/record-structs#open-questions
		// recognizing record structs from metadata is an open point. The following check is based on common sense
		// and heuristic testing, apparently giving good results but not supported by official documentation.
		return type.BaseType == typeof(ValueType) &&
			type.GetMethod("PrintMembers", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly, null,
				[typeof(StringBuilder)], null) is { } &&
			type.GetMethod("op_Equality", BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly, null,
					[type, type], null)?
				.IsDecoratedWith<CompilerGeneratedAttribute>() == true;
	}
}
