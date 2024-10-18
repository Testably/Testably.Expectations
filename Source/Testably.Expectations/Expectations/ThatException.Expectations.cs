using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatException<TException>
	where TException : Exception
{
	private readonly struct HasInnerExceptionExpectation<T> : INullableExpectation<Exception>,
		IDelegateExpectation<object>
		where T : Exception
	{
		public ExpectationResult IsMetBy(SourceValue<object> value)
		{
			return IsMetBy(value.Exception as T);
		}


		/// <inheritdoc />
		public ExpectationResult IsMetBy(Exception? actual)
		{
			if (actual?.InnerException is T exception)
			{
				return new ExpectationResult.Success<T?>(exception, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				"found none");
		}

		public override string ToString()
			=> "has InnerException";
	}

	private readonly struct HasMessageExpectation<T> : INullableExpectation<T>,
		IDelegateExpectation<DelegateSource.NoValue>
		where T : Exception
	{
		private readonly string _expected;

		public HasMessageExpectation(string expected)
		{
			_expected = expected;
		}

		public ExpectationResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ExpectationResult IsMetBy(T? actual)
		{
			if (_expected.Equals(actual?.Message))
			{
				return new ExpectationResult.Success<T?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual?.Message)} which {new StringDifference(actual?.Message, _expected)}");
		}

		public override string ToString()
			=> $"has Message equal to {Formatter.Format(_expected)}";
	}
}
