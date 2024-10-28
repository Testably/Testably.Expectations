using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatGenericShould
{
	/// <summary>
	///     Expect the actual value to be the same as the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<T, IThat<T>> BeSameAs<T>(this IThat<T> source,
		object? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsSameAsValueConstraint<T>(expected, doNotPopulateThisValue),
				b => b.AppendMethod(nameof(BeSameAs), doNotPopulateThisValue)),
			source);

	private readonly struct IsSameAsValueConstraint<T>(object? expected, string expectedExpression)
		: IValueConstraint<T?>
	{
		public ConstraintResult IsMetBy(T? actual)
		{
			if (ReferenceEquals(actual, expected))
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"refer to {expectedExpression} {Formatter.Format(expected)}";
	}
}
