using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	private readonly struct DoesNotThrowExpectation<TValue> : IDelegateExpectation<TValue>
	{
		public ExpectationResult IsMetBy(SourceValue<TValue> value)
		{
			if (value.Exception is not null)
			{
				return new ExpectationResult.Failure<TValue?>(value.Value, ToString(),
					$"it did throw {Formatter.PrependAOrAn(value.Exception.GetType().Name)}:{Environment.NewLine}\t{value.Exception.Message}");
			}

			return new ExpectationResult.Success<TValue?>(value.Value, ToString());
		}

		public override string ToString()
			=> "does not throw any exception";
	}

	private readonly struct ThrowsExpectation<TException> : IDelegateExpectation<DelegateSource.WithoutValue>
		where TException : Exception
	{
		public ExpectationResult IsMetBy(SourceValue<DelegateSource.WithoutValue> actual)
		{
			if (actual.Exception is TException typedException)
			{
				return new ExpectationResult.Success<TException?>(typedException, ToString());
			}

			if (actual.Exception is null)
			{
				return new ExpectationResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ExpectationResult.Failure<TException?>(null, ToString(),
				$"it did throw {Formatter.PrependAOrAn(actual.Exception.GetType().Name)}:{Environment.NewLine}\t{actual.Exception.Message}");
		}

		public override string ToString()
			=> $"throws {Formatter.PrependAOrAn(typeof(TException).Name)}";
	}

	private readonly struct ThrowsExactlyExpectation<TException> : IDelegateExpectation
		where TException : Exception
	{
		#region IDelegateExpectation Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(Exception? exception)
		{
			if (exception is TException typedException && exception.GetType() == typeof(TException))
			{
				return new ExpectationResult.Success<TException?>(typedException, ToString());
			}

			if (exception is null)
			{
				return new ExpectationResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ExpectationResult.Failure<TException?>(null, ToString(),
				$"it did throw {Formatter.PrependAOrAn(exception.GetType().Name)}:{Environment.NewLine}\t{exception.Message}");
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> $"throws {Formatter.PrependAOrAn(typeof(TException).Name)}";
	}
}
