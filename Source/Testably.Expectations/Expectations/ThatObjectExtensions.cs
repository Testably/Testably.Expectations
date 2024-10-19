using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="object" /> values.
/// </summary>
public static class ThatObjectExtensions
{
	/// <summary>
	///     Expect the actual value to be of type <typeparamref name="TType" />.
	/// </summary>
	public static AssertionResultWhich<TType, That<object>> Is<TType>(this That<object> source)
		=> new(source.ExpectationBuilder.Add(
				new IsExpectation<TType>(),
				b => b.Append('.').Append(nameof(Is)).Append('<').Append(typeof(TType).Name)
					.Append(">()")),
			source);

	/// <summary>
	///     Expect the actual value to be equivalent to the <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResult<T, That<T>> IsEquivalentTo<T>(this That<T> source,
		object expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsEquivalentToExpectation(expected),
				b => b.AppendMethod(nameof(IsEquivalentTo), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the value satisfies the <paramref name="expectations" /> on the properties selected by the
	///     <paramref name="selector" />.
	/// </summary>
	public static AssertionResult<T, That<object?>> Satisfies<T, TProperty>(
		this That<object?> source,
		Expression<Func<T, TProperty?>> selector,
		Action<That<TProperty?>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue2 = "")
		=> new(source.ExpectationBuilder.Which<T, TProperty?>(
				PropertyAccessor<T, TProperty?>.FromExpression(selector),
				expectations,
				b => b.AppendGenericMethod<T, TProperty>(nameof(Satisfies), doNotPopulateThisValue1,
					doNotPopulateThisValue2),
				whichTextSeparator: "satisfies "),
			source);

	private readonly struct IsExpectation<TType> : IExpectation<object?>
	{
		public ExpectationResult IsMetBy(object? actual)
		{
			if (actual is TType typedActual)
			{
				return new ExpectationResult.Success<TType>(typedActual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is type {Formatter.Format(typeof(TType))}";
	}

	private readonly struct IsEquivalentToExpectation(object? expected) : IExpectation<object?>
	{
		public ExpectationResult IsMetBy(object? actual)
		{
			if (actual == expected)
			{
				return new ExpectationResult.Success<object?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is equivalent to {Formatter.Format(expected)}";
	}
}
