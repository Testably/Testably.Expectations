using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public abstract partial class ThatDelegate
{
	private readonly struct DoesNotThrowConstraint<TValue> : IDelegateExpectation<TValue>
	{
		public ConstraintResult IsMetBy(SourceValue<TValue> value)
		{
			if (value.Exception is not null)
			{
				return new ConstraintResult.Failure<TValue?>(value.Value, ToString(),
					$"it did throw {value.Exception.GetType().Name.PrependAOrAn()}:{Environment.NewLine}{value.Exception.Message.Indent()}");
			}

			return new ConstraintResult.Success<TValue?>(value.Value, ToString());
		}

		public override string ToString()
			=> "does not throw any exception";
	}
}
