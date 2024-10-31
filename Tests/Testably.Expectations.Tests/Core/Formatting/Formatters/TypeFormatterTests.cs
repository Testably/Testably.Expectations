using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.Core.Formatting.Formatters;

public sealed class TypeFormatterTests
{
	#region Test Setup

	public static TheoryData<Type, string> SimpleTypes
		=> new()
		{
			{ typeof(int), "int" },
			{ typeof(int?), "int?" },
			{ typeof(uint), "uint" },
			{ typeof(uint?), "uint?" },
			{ typeof(nint), "nint" },
			{ typeof(nint?), "nint?" },
			{ typeof(nuint), "nuint" },
			{ typeof(nuint?), "nuint?" },
			{ typeof(byte), "byte" },
			{ typeof(byte?), "byte?" },
			{ typeof(sbyte), "sbyte" },
			{ typeof(sbyte?), "sbyte?" },
			{ typeof(short), "short" },
			{ typeof(short?), "short?" },
			{ typeof(ushort), "ushort" },
			{ typeof(ushort?), "ushort?" },
			{ typeof(long), "long" },
			{ typeof(long?), "long?" },
			{ typeof(ulong), "ulong" },
			{ typeof(ulong?), "ulong?" },
			{ typeof(float), "float" },
			{ typeof(float?), "float?" },
			{ typeof(double), "double" },
			{ typeof(double?), "double?" },
			{ typeof(decimal), "decimal" },
			{ typeof(decimal?), "decimal?" },
			{ typeof(string), "string" },
			{ typeof(object), "object" },
			{ typeof(bool), "bool" },
			{ typeof(bool?), "bool?" },
			{ typeof(char), "char" },
			{ typeof(char?), "char?" },
			{ typeof(void), "void" },
		};

	#endregion

	[Theory]
	[MemberData(nameof(SimpleTypes))]
	public async Task SimpleTypes_ShouldUseSimpleNames(Type value, string expectedResult)
	{
		string result = Formatter.Format(value);

		await That(result).Should().Be(expectedResult);
	}

	[Fact]
	public async Task Types_ShouldOnlyIncludeTheName()
	{
		Type value = typeof(BooleanFormatterTests);
		string result = Formatter.Format(value);

		await That(result).Should().Be(nameof(BooleanFormatterTests));
	}
}
