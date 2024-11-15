using System;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations;

/// <summary>
///     Expectations on generic values.
/// </summary>
public static partial class ThatGeneric
{
	private readonly struct ConditionConstraint<T>(
		T expected,
		string expectation,
		Func<T, T, bool> condition,
		Func<T, T, string> failureMessageFactory)
		: IValueConstraint<T>
	{
		public ConstraintResult IsMetBy(T actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<T>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> expectation;
	}
}
