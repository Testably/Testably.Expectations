using System;

namespace Testably.Expectations.Core;

public abstract class ExpectationResult
{
	public static ExpectationResult Copy<T>(
		ExpectationResult result,
		T value,
		Func<Failure, string>? expectationText = null,
		Func<Failure, string>? resultText = null)
	{
		if (result is not Failure failure)
		{
			return new Success<T>(value);
		}

		expectationText ??= f => f.ExpectationText;
		resultText ??= f => f.ResultText;
		return new Failure<T>(value, expectationText.Invoke(failure), resultText.Invoke(failure));
	}

	public class Success : ExpectationResult;

	public class Success<T> : Success
	{
		public T? Value { get; }

		public Success(T? value)
		{
			Value = value;
		}
	}

	public class Failure : ExpectationResult
	{
		public string ExpectationText { get; }
		public string ResultText { get; }

		public Failure(string expectationText, string resultText)
		{
			ExpectationText = expectationText;
			ResultText = resultText;
		}
	}

	public class Failure<T> : Failure
	{
		public T? Value { get; }

		public Failure(T? value, string expectationText, string resultText) : base(expectationText,
			resultText)
		{
			Value = value;
		}
	}
}
