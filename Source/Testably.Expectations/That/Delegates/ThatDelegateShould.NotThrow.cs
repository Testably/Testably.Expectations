using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDelegateShould
{
	/// <summary>
	///     Verifies that the delegate does not throw any exception.
	/// </summary>
	public static ExpectationResult<TValue> NotThrow<TValue>(
		this ThatDelegate.WithValue<TValue> source)
		=> new(source.ExpectationBuilder.Add(
			new DoesNotThrowConstraint<TValue>(),
			b => b.AppendMethod(nameof(NotThrow))));

	/// <summary>
	///     Verifies that the delegate does not throw any exception.
	/// </summary>
	public static ExpectationResult NotThrow(this ThatDelegate.WithoutValue source)
		=> new(source.ExpectationBuilder.Add(
			new DoesNotThrowConstraint<DelegateSource.NoValue>(),
			b => b.AppendMethod(nameof(NotThrow))));

	private readonly struct DoesNotThrowConstraint<TValue> : IComplexConstraint<TValue>
	{
		public ConstraintResult IsMetBy(TValue? actual, Exception? exception)
		{
			if (exception is not null)
			{
				return new ConstraintResult.Failure<TValue?>(actual, ToString(),
					$"it did throw {exception.FormatForMessage()}");
			}

			return new ConstraintResult.Success<TValue?>(actual, ToString());
		}

		public override string ToString()
			=> DoesNotThrowExpectation;
	}
}
