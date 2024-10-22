using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Sources;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatExceptionExtensions
{
	private readonly struct HasMessageConstraint<T>(StringMatcher expected) : IConstraint<T>,
		IDelegateConstraint<DelegateSource.NoValue>
		where T : Exception?
	{
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ConstraintResult IsMetBy(T? actual)
		{
			if (expected.Matches(actual?.Message))
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				expected.GetExtendedFailure(actual?.Message));
		}

		public override string ToString()
			=> $"has Message {expected.GetExpectation(GrammaticVoice.PassiveVoice)}";
	}
}
