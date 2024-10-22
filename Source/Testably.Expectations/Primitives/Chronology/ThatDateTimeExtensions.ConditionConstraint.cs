using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDateTimeExtensions
{
	private readonly struct ConditionConstraint(
		DateTime expected,
		Func<DateTime, DateTime, TimeSpan, bool> condition,
		string expectation,
		TimeTolerance tolerance) : IConstraint<DateTime>
	{
		public ConstraintResult IsMetBy(DateTime actual)
		{
			_ = tolerance;
			if (condition(actual, expected, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<DateTime>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation + tolerance;
	}
}
