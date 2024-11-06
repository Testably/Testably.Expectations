using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatDelegateShould
{
	/// <summary>
	///     Verifies that the delegate finishes execution within the given <paramref name="duration" />.
	/// </summary>
	public static ExpectationResult<TValue> ExecuteWithin<TValue>(
		this ThatDelegate.WithValue<TValue> source,
		TimeSpan duration,
		[CallerArgumentExpression("duration")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
			.AddConstraint(new ExecuteWithinConstraint<TValue>(duration))
			.AppendMethodStatement(nameof(ExecuteWithin), doNotPopulateThisValue));

	/// <summary>
	///     Verifies that the delegate finishes execution within the given <paramref name="duration" />.
	/// </summary>
	public static ExpectationResult ExecuteWithin(
		this ThatDelegate.WithoutValue source,
		TimeSpan duration,
		[CallerArgumentExpression("duration")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
			.AddConstraint(new ExecuteWithinConstraint(duration))
			.AppendMethodStatement(nameof(ExecuteWithin), doNotPopulateThisValue));

	/// <summary>
	///     Verifies that the delegate does not finish execution within the given <paramref name="duration" />.
	/// </summary>
	public static ExpectationResult<TValue> NotExecuteWithin<TValue>(
		this ThatDelegate.WithValue<TValue> source,
		TimeSpan duration,
		[CallerArgumentExpression("duration")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
			.AddConstraint(new NotExecuteWithinConstraint<TValue>(duration))
			.AppendMethodStatement(nameof(NotExecuteWithin), doNotPopulateThisValue));

	/// <summary>
	///     Verifies that the delegate does not finish execution within the given <paramref name="duration" />.
	/// </summary>
	public static ExpectationResult NotExecuteWithin(
		this ThatDelegate.WithoutValue source,
		TimeSpan duration,
		[CallerArgumentExpression("duration")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
			.AddConstraint(new NotExecuteWithinConstraint(duration))
			.AppendMethodStatement(nameof(NotExecuteWithin), doNotPopulateThisValue));

	private readonly struct ExecuteWithinConstraint<TValue>(TimeSpan duration)
		: IValueConstraint<DelegateValue<TValue>>
	{
		public ConstraintResult IsMetBy(DelegateValue<TValue> actual)
		{
			if (actual.Exception is { } exception)
			{
				return new ConstraintResult.Failure<TValue?>(actual.Value, ToString(),
					$"it did throw {exception.FormatForMessage()}");
			}

			if (actual.Duration <= duration)
			{
				return new ConstraintResult.Success<TValue?>(actual.Value, ToString());
			}

			return new ConstraintResult.Failure<TValue?>(actual.Value, ToString(),
				$"it took {Formatter.Format(actual.Duration)}");
		}

		public override string ToString()
			=> $"execute within {Formatter.Format(duration)}";
	}

	private readonly struct ExecuteWithinConstraint(TimeSpan duration)
		: IValueConstraint<DelegateValue>
	{
		public ConstraintResult IsMetBy(DelegateValue actual)
		{
			if (actual.Exception is { } exception)
			{
				return new ConstraintResult.Failure(ToString(),
					$"it did throw {exception.FormatForMessage()}");
			}

			if (actual.Duration <= duration)
			{
				return new ConstraintResult.Success(ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"it took {Formatter.Format(actual.Duration)}");
		}

		public override string ToString()
			=> $"execute within {Formatter.Format(duration)}";
	}

	private readonly struct NotExecuteWithinConstraint<TValue>(TimeSpan duration)
		: IValueConstraint<DelegateValue<TValue>>
	{
		public ConstraintResult IsMetBy(DelegateValue<TValue> actual)
		{
			if (actual.Exception is not null || actual.Duration > duration)
			{
				return new ConstraintResult.Success<TValue?>(actual.Value, ToString());
			}

			return new ConstraintResult.Failure<TValue?>(actual.Value, ToString(),
				$"it took only {Formatter.Format(actual.Duration)}");
		}

		public override string ToString()
			=> $"not execute within {Formatter.Format(duration)}";
	}

	private readonly struct NotExecuteWithinConstraint(TimeSpan duration)
		: IValueConstraint<DelegateValue>
	{
		public ConstraintResult IsMetBy(DelegateValue actual)
		{
			if (actual.Exception is not null || actual.Duration > duration)
			{
				return new ConstraintResult.Success(ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"it took only {Formatter.Format(actual.Duration)}");
		}

		public override string ToString()
			=> $"not execute within {Formatter.Format(duration)}";
	}
}
