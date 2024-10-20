using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	private readonly struct DoesNotThrowExpectation<TValue> : IDelegateExpectation<TValue>
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

	private readonly struct ThrowsExpectation<TException> :
		IExpectation<DelegateSource.NoValue, TException>,
		IDelegateExpectation<DelegateSource.NoValue>
		where TException : Exception
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			if (exception is TException typedException)
			{
				return new ConstraintResult.Success<TException?>(typedException, ToString());
			}

			if (exception is null)
			{
				return new ConstraintResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ConstraintResult.Failure<TException?>(null, ToString(),
				$"it did throw {exception.GetType().Name.PrependAOrAn()}:{Environment.NewLine}\t{exception.Message}");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
			=> IsMetBy(value.Value, value.Exception);

		public override string ToString()
			=> $"throws {typeof(TException).Name.PrependAOrAn()}";
	}

	private readonly struct ThrowsExactlyExpectation<TException> :
		IExpectation<DelegateSource.NoValue, TException>,
		IDelegateExpectation<DelegateSource.NoValue>
		where TException : Exception
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			if (exception is TException typedException && exception.GetType() == typeof(TException))
			{
				return new ConstraintResult.Success<TException?>(typedException, ToString());
			}

			if (exception is null)
			{
				return new ConstraintResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ConstraintResult.Failure<TException?>(null, ToString(),
				$"it did throw {exception.GetType().Name.PrependAOrAn()}:{Environment.NewLine}\t{exception.Message}");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
			=> IsMetBy(value.Value, value.Exception);

		/// <inheritdoc />
		public override string ToString()
			=> $"throws exactly {typeof(TException).Name.PrependAOrAn()}";
	}
}
