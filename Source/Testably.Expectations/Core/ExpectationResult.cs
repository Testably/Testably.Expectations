using System;

namespace Testably.Expectations.Core;

/// <summary>
///     The result of the check if an expectation is met.
/// </summary>
public abstract class ExpectationResult
{
	/// <summary>
	///     Copies the <paramref name="result" /> by keeping the result, adding the <paramref name="value" /> and (optionally)
	///     updating the <paramref name="expectationText" /> and <paramref name="resultText" />.
	/// </summary>
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

	/// <summary>
	///     The actual value met the expectation.
	/// </summary>
	public class Success : ExpectationResult;

	/// <summary>
	///     The actual value met the expectation and a <see cref="Value" /> is stored for further processing.
	/// </summary>
	public class Success<T> : Success
	{
		/// <summary>
		///     A value for further processing.
		/// </summary>
		public T? Value { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Success{T}" />.
		/// </summary>
		public Success(T? value)
		{
			Value = value;
		}
	}

	/// <summary>
	///     The actual value did not meet the expectation.
	/// </summary>
	public class Failure : ExpectationResult
	{
		/// <summary>
		///     A human-readable representation of the expectation.
		/// </summary>
		public string ExpectationText { get; }

		/// <summary>
		///     A human-readable representation of the reason for the failure.
		/// </summary>
		public string ResultText { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Failure" />.
		/// </summary>
		public Failure(string expectationText, string resultText)
		{
			ExpectationText = expectationText;
			ResultText = resultText;
		}
	}

	/// <summary>
	///     The actual value did not meet the expectation and a <see cref="Value" /> is stored for further processing.
	/// </summary>
	public class Failure<T> : Failure
	{
		/// <summary>
		///     A value for further processing.
		/// </summary>
		public T? Value { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Failure{T}" />.
		/// </summary>
		public Failure(T? value, string expectationText, string resultText) : base(expectationText,
			resultText)
		{
			Value = value;
		}
	}
}
