using System;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Core.Helpers;

internal static class ExpectationBuilderHelpers
{
	public static ExpectationBuilder.PropertyExpectationBuilder<TSource, TTarget> ForProperty<
		TSource, TTarget>(
		this ExpectationBuilder expectationBuilder,
		Func<TSource, TTarget> func, string name)
	{
		return expectationBuilder.ForProperty(
			PropertyAccessor<TSource, TTarget>.FromFunc(func, name));
	}
	
	public static ExpectationBuilder AppendGenericMethodStatement<T1>(this ExpectationBuilder builder,
		string methodName)
	{
		return builder.AppendStatement(".").AppendStatement(methodName)
			.AppendStatement("<").AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(">")
			.AppendStatement("(").AppendStatement(")");
	}

	public static ExpectationBuilder AppendGenericMethodStatement<T1>(this ExpectationBuilder builder,
		string methodName, string param1)
	{
		return builder.AppendStatement(".").AppendStatement(methodName)
			.AppendStatement("<").AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(">")
			.AppendStatement("(").AppendStatement(param1).AppendStatement(")");
	}

	public static ExpectationBuilder AppendGenericMethodStatement<T1, T2>(this ExpectationBuilder builder,
		string methodName, string param1)
	{
		return builder.AppendStatement(".").AppendStatement(methodName)
			.AppendStatement("<").AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(", ")
			.AppendStatement(Formatter.Format(typeof(T2))).AppendStatement(">")
			.AppendStatement("(").AppendStatement(param1).AppendStatement(")");
	}

	public static ExpectationBuilder AppendGenericMethodStatement<T1, T2>(this ExpectationBuilder builder,
		string methodName, string param1, string param2)
	{
		return builder.AppendStatement(".").AppendStatement(methodName)
			.AppendStatement("<").AppendStatement(Formatter.Format(typeof(T1))).AppendStatement(", ")
			.AppendStatement(Formatter.Format(typeof(T2))).AppendStatement(">")
			.AppendStatement("(").AppendStatement(param1).AppendStatement(", ").AppendStatement(param2).AppendStatement(")");
	}

	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder, string methodName)
	{
		return builder.AppendStatement(".").AppendStatement(methodName).AppendStatement("(").AppendStatement(")");
	}

	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder, string methodName,
		string param1)
	{
		return builder.AppendStatement(".").AppendStatement(methodName).AppendStatement("(").AppendStatement(param1).AppendStatement(")");
	}

	public static ExpectationBuilder AppendMethodStatement(this ExpectationBuilder builder, string methodName,
		string param1, string param2)
	{
		return builder.AppendStatement(".").AppendStatement(methodName).AppendStatement("(").AppendStatement(param1).AppendStatement(", ")
			.AppendStatement(param2).AppendStatement(")");
	}
}
