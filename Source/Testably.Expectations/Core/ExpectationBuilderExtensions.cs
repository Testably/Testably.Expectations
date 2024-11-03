using System;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Core;

/// <summary>
///     Extension methods to simplify usage of the <see cref="ExpectationBuilder" />.
/// </summary>
public static class ExpectationBuilderExtensions
{
	/// <summary>
	///     Appends the statement with the generic method with one type parameter and no method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />&gt;()
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1>(
		this ExpectationBuilder builder,
		string methodName)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(">")
			.AppendStatement("(").AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with one type parameter and one method parameter.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />&gt;(<paramref name="param1" />)
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1>(
		this ExpectationBuilder builder,
		string methodName, string param1)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(">")
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with one type parameter and two method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />&gt;(<paramref name="param1" />,
	///     <paramref name="param2" />)
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1>(
		this ExpectationBuilder builder,
		string methodName, string param1, string param2)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(">")
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with one type parameter and three method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />&gt;(<paramref name="param1" />,
	///     <paramref name="param2" />, <paramref name="param3" />)
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1>(
		this ExpectationBuilder builder,
		string methodName, string param1, string param2, string param3)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(">")
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(", ")
			.AppendStatement(param3).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with two type parameters and no method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />, <typeparamref name="T2" />&gt;()
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1, T2>(
		this ExpectationBuilder builder,
		string methodName)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(", ")
			.AppendStatement(Formatter.Format(typeof(T2))).AppendStatement(">")
			.AppendStatement("(").AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with two type parameters and one method parameter.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />, <typeparamref name="T2" />&gt;(
	///     <paramref name="param1" />)
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1, T2>(
		this ExpectationBuilder builder,
		string methodName, string param1)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(", ")
			.AppendStatement(Formatter.Format(typeof(T2))).AppendStatement(">")
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with two type parameters and two method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />, <typeparamref name="T2" />&gt;(
	///     <paramref name="param1" />, <paramref name="param2" />)
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1, T2>(
		this ExpectationBuilder builder,
		string methodName, string param1, string param2)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(", ")
			.AppendStatement(Formatter.Format(typeof(T2))).AppendStatement(">")
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the generic method with two type parameters and three method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />&lt;<typeparamref name="T1" />, <typeparamref name="T2" />&gt;(
	///     <paramref name="param1" />, <paramref name="param2" />, <paramref name="param3" />)
	/// </remarks>
	public static ExpectationBuilder AppendGenericMethodStatement<T1, T2>(
		this ExpectationBuilder builder,
		string methodName, string param1, string param2, string param3)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("<")
			.AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(", ")
			.AppendStatement(Formatter.Format(typeof(T2))).AppendStatement(">")
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(", ")
			.AppendStatement(param3).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the method without method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />()
	/// </remarks>
	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder,
		string methodName)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("()");
	}

	/// <summary>
	///     Appends the statement with the method with one method parameter.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />(<paramref name="param1" />)
	/// </remarks>
	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder,
		string methodName,
		string param1)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the method with two method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />(<paramref name="param1" />, <paramref name="param2" />)
	/// </remarks>
	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder,
		string methodName,
		string param1,
		string param2)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(")");
	}

	/// <summary>
	///     Appends the statement with the method with three method parameters.
	/// </summary>
	/// <remarks>
	///     Format: <br />
	///     .<paramref name="methodName" />(<paramref name="param1" />, <paramref name="param2" />, <paramref name="param3" />)
	/// </remarks>
	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder,
		string methodName,
		string param1,
		string param2,
		string param3)
	{
		return builder.AppendStatement(".")
			.AppendStatement(methodName)
			.AppendStatement("(")
			.AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(", ")
			.AppendStatement(param3).AppendStatement(")");
	}

	/// <summary>
	///     Specifies a constraint that applies to the property selected
	///     by the <paramref name="propertySelector" /> displayed as <paramref name="displayName" />.
	/// </summary>
	public static ExpectationBuilder.PropertyExpectationBuilder<TSource, TTarget>
		ForProperty<TSource, TTarget>(
			this ExpectationBuilder expectationBuilder,
			Func<TSource, TTarget> propertySelector,
			string displayName)
		=> expectationBuilder.ForProperty(
			PropertyAccessor<TSource, TTarget>.FromFunc(propertySelector, displayName));
}
