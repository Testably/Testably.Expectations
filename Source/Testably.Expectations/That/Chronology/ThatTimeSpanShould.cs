using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="TimeSpan" /> values.
/// </summary>
public static partial class ThatTimeSpanShould
{
	private readonly struct ConditionConstraint(
		TimeSpan expected,
		Func<TimeSpan, TimeSpan, bool> condition,
		string expectation) : IConstraint<TimeSpan>
	{
		public ConstraintResult IsMetBy(TimeSpan actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<TimeSpan>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
