using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on generic values.
/// </summary>
public static partial class ThatGenericShould
{
	private readonly struct ConditionConstraint<T>(
		T expected,
		string expectation,
		Func<T, T, bool> condition,
		Func<T, T, string> failureMessageFactory)
		: IValueConstraint<T>
	{
		private readonly string _expectation = expectation;

		public ConstraintResult IsMetBy(T actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<T>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> _expectation;
	}
}
