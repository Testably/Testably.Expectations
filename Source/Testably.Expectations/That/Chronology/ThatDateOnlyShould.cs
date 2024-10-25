#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateOnly" /> values.
/// </summary>
public static partial class ThatDateOnlyShould
{
	private readonly struct ConditionConstraint(
		DateOnly expected,
		Func<DateOnly, DateOnly, bool> condition,
		string expectation) : IConstraint<DateOnly>
	{
		public ConstraintResult IsMetBy(DateOnly actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<DateOnly>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
#endif
