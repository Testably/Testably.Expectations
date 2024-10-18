using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatException<TException>
	where TException : Exception
{
	private readonly struct HasInnerExceptionExpectation<TInnerException>(
		Action<ThatException<TInnerException>> assertions)
		: IExpectation<TInnerException>,
			IDelegateExpectation<DelegateSource.NoValue>
		where TInnerException : Exception
	{
		/// <inheritdoc />
		public ExpectationResult IsMetBy(TInnerException actual)
		{
			_ = assertions;
			if (actual?.InnerException is TInnerException exception)
			{
				return new ExpectationResult.Success<TInnerException?>(exception, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				"it did not");
		}

		/// <inheritdoc />
		public ExpectationResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			if (value.Exception?.InnerException is TInnerException exception)
			{
				return new ExpectationResult.Success<TInnerException?>(exception, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				"it did not");
		}

		public override string ToString()
			=> "has an inner exception";
	}

	private readonly struct HasMessageExpectation<T>(string expected) : IExpectation<T>,
		IDelegateExpectation<DelegateSource.NoValue>
		where T : Exception
	{
		public ExpectationResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ExpectationResult IsMetBy(T? actual)
		{
			if (expected.Equals(actual?.Message))
			{
				return new ExpectationResult.Success<T?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual?.Message)} which {new StringDifference(actual?.Message, expected)}");
		}

		public override string ToString()
			=> $"has Message equal to {Formatter.Format(expected)}";
	}
}
