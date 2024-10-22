using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDateTimeOffsetExtensions
{
	private readonly struct IsConstraint(DateTimeOffset expected) : IConstraint<DateTimeOffset>
	{
		public ConstraintResult IsMetBy(DateTimeOffset actual)
		{
			if (expected.Equals(actual))
			{
				return new ConstraintResult.Success<DateTimeOffset>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
