#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatTimeOnlyExtensions
{
	private readonly struct IsConstraint(TimeOnly expected) : IConstraint<TimeOnly>
	{
		public ConstraintResult IsMetBy(TimeOnly actual)
		{
			if (expected.Equals(actual))
			{
				return new ConstraintResult.Success<TimeOnly>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"is {Formatter.Format(expected)}";
	}
}
#endif
