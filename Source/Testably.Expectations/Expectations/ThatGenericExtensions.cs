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
