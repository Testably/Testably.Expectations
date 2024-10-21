#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDateOnlyExtensions
{
	private readonly struct IsConstraint(DateOnly expected) : IConstraint<DateOnly>
	{
		public ConstraintResult IsMetBy(DateOnly actual)
		{
			if (expected.Equals(actual))
			{
				return new ConstraintResult.Success<DateOnly>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
#endif
