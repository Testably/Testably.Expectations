using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateTimeOffset" /> values.
/// </summary>
public static partial class ThatDateTimeOffsetShould
{
	private readonly struct ConditionConstraint(
		DateTimeOffset expected,
		Func<DateTimeOffset, DateTimeOffset, bool> condition,
		string expectation) : IConstraint<DateTimeOffset>
	{
		public ConstraintResult IsMetBy(DateTimeOffset actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<DateTimeOffset>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
