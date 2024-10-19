using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static class ThatObjectExtensions
{
	/// <summary>
	///     Expect the actual value to be of type <typeparamref name="TType"/>.
	/// </summary>
	public static AssertionResultWhich<TType, That<object>> Is<TType>(this That<object> source)
		=> new(source.ExpectationBuilder.Add(
				new IsExpectation<TType>(),
				b => b.Append('.').Append(nameof(Is)).Append('<').Append(typeof(TType).Name).Append(">()")),
			source);

	/// <summary>
	///     Expect the actual value to be equivalent to the <paramref name="expected"/> value.
	/// </summary>
	public static AssertionResult<object, That<object>> IsEquivalentTo(this That<object> source,
		object expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsEquivalentToExpectation(expected),
				b => b.AppendMethod(nameof(IsEquivalentTo), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Expect the actual value to be the same as the <paramref name="expected"/> value.
	/// </summary>
	public static AssertionResult<T, That<T>> IsSameAs<T>(this That<T> source,
		object? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsSameAsExpectation<T>(expected),
				b => b.AppendMethod(nameof(IsSameAs), doNotPopulateThisValue)),
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
	private readonly struct IsSameAsExpectation<T>(object? expected) : IExpectation<T?>
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
			=> $"is same as {Formatter.Format(expected)}";
	}
}
