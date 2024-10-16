using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

public abstract partial class DelegateExpectations
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
			=> "does not throw";
	}

	private readonly struct ThrowsExpectation<TException> : IDelegateExpectation
		where TException : Exception
	{
		public ExpectationResult IsMetBy(Exception? exception)
		{
			if (exception is TException typedException)
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
