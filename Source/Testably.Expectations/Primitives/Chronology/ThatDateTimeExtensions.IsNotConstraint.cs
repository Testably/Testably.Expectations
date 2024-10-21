using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDateTimeExtensions
{
	private readonly struct IsNotConstraint(DateTime unexpected, TimeTolerance tolerance) : IConstraint<DateTime>
	{
		public ConstraintResult IsMetBy(DateTime actual)
		{
			if (!tolerance.IsWithinTolerance(actual - unexpected))
			{
				return new ConstraintResult.Success<DateTime>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is not {Formatter.Format(unexpected)}{tolerance}";
	}
}
