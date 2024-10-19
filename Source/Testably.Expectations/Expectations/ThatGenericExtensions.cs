using System.Linq.Expressions;
using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static class ThatGenericExtensions
{
	/// <summary>
	///     Expect the actual value to be the same as the <paramref name="expected"/> value.
	/// </summary>
	public static AssertionResult<T, That<T>> IsSameAs<T>(this That<T> source,
		object? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsSameAsExpectation<T>(expected, doNotPopulateThisValue),
	b => b.AppendMethod(nameof(IsSameAs), doNotPopulateThisValue)),
	source);

	public static AssertionResult<T, That<T>> Satisfies<T, TProperty>(this That<T> source, Expression<Func<T, TProperty>> selector,
		Action<That<TProperty>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")] string doNotPopulateThisValue2 = "")
		=> new(source.ExpectationBuilder.Which<T, TProperty>(
			PropertyAccessor<T, TProperty>.FromExpression(selector),
			expectations,
			b => b.AppendMethod(nameof(Satisfies), doNotPopulateThisValue1, doNotPopulateThisValue2)),
			source);

	private readonly struct IsSameAsExpectation<T>(object? expected, string expectedExpression) : IExpectation<T?>
	{
		public ExpectationResult IsMetBy(T? actual)
		{
			if (ReferenceEquals(actual, expected))
			{
				return new ExpectationResult.Success<T?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"refers to {expectedExpression} {Formatter.Format(expected)}";
	}
}
