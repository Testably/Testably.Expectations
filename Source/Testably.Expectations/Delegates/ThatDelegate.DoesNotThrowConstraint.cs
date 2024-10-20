using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public abstract partial class ThatDelegate
{
	private static readonly string DoesNotThrowExpectation = "does not throw any exception";

	private static ConstraintResult DoesNotThrowResult(Exception? exception)
	{
		if (exception is not null)
		{
			return new ConstraintResult.Failure<Exception?>(exception, DoesNotThrowExpectation,
				$"it did throw {exception.FormatForMessage()}");
		}

		return new ConstraintResult.Success<Exception?>(null, DoesNotThrowExpectation);
	}

	private readonly struct DoesNotThrowConstraint<TValue> : IDelegateConstraint<TValue>
	{
		public ConstraintResult IsMetBy(SourceValue<TValue> value)
		{
			if (value.Exception is not null)
			{
				return new ConstraintResult.Failure<TValue?>(value.Value, ToString(),
					$"it did throw {value.Exception.FormatForMessage()}");
			}

			return new ConstraintResult.Success<TValue?>(value.Value, ToString());
		}

		public override string ToString()
			=> DoesNotThrowExpectation;
	}
}
