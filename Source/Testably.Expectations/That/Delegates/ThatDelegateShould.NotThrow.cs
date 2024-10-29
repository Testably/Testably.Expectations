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
		=> new(source.ExpectationBuilder
			.AddConstraint(new DoesNotThrowConstraint<TValue>())
			.AppendMethodStatement(nameof(NotThrow)));

	/// <summary>
	///     Verifies that the delegate does not throw any exception.
	/// </summary>
	public static ExpectationResult NotThrow(this ThatDelegate.WithoutValue source)
		=> new(source.ExpectationBuilder
			.AddConstraint(new DoesNotThrowConstraint<DelegateSource.NoValue>())
			.AppendMethodStatement(nameof(NotThrow)));

	private readonly struct DoesNotThrowConstraint<TValue> : IValueConstraint<DelegateValue<TValue>>
	{
		public ConstraintResult IsMetBy(DelegateValue<TValue>? actual)
		{
			if (actual?.Exception is { } exception)
			{
				return new ConstraintResult.Failure<TValue?>(actual.Value, ToString(),
					$"it did throw {exception.FormatForMessage()}");
			}

			if (actual is not null)
			{
				return new ConstraintResult.Success<TValue?>(actual.Value, ToString());
			}

			throw new InvalidOperationException("Received <null> in DoesNotThrowConstraint.");
		}

		public override string ToString()
			=> DoesNotThrowExpectation;
	}
}
