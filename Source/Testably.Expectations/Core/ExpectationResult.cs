using System;
using static Testably.Expectations.Core.ExpectationResult;

namespace Testably.Expectations.Core;

public abstract class ExpectationResult
{
	public class Success : ExpectationResult
	{
		public Success()
		{

		}
	}

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
		public Failure(string expectationText, string resultText)
		{
			ExpectationText = expectationText;
			ResultText = resultText;
		}

		public string ExpectationText { get; }
		public string ResultText { get; }
	}

	public class Failure<T> : Failure
	{
		public T? Value { get; }
		public Failure(T? value, string expectationText, string resultText) : base(expectationText, resultText)
		{
			Value = value;
		}
	}

	public static ExpectationResult Copy(
		ExpectationResult result,
		Func<Failure, string>? expectationText = null,
		Func<Failure, string>? resultText = null)
	{
		if (result is not Failure failure)
		{
			return new Success();
		}

		expectationText ??= f => f.ExpectationText;
		resultText ??= f => f.ResultText;
		return new Failure(expectationText.Invoke(failure), resultText.Invoke(failure));
	}

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

	public static ExpectationResult BySuccess<T>(
		bool isSuccess,
		T value,
		string expectationText,
		string resultText)
	{
		if (isSuccess)
		{
			return new Success<T>(value);
		}

		return new Failure<T>(value, expectationText, resultText);
	}
}
