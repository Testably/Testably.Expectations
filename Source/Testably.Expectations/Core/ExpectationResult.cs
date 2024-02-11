using System;

namespace Testably.Expectations.Core;

/// <summary>
///     The result of the check if an expectation is met.
/// </summary>
public abstract class ExpectationResult
{
	private const string InvertDefaultResultText = "it did";

	/// <summary>
	///     A human-readable representation of the expectation.
	/// </summary>
	public string ExpectationText { get; }

	/// <summary>
	///     Initializes a new instance of <see cref="ExpectationResult" />.
	/// </summary>
	protected ExpectationResult(string expectationText)
	{
		ExpectationText = expectationText;
	}

	/// <summary>
	///     Copies the <paramref name="result" /> by keeping the result, adding the <paramref name="value" /> and (optionally)
	///     updating the <paramref name="expectationText" /> and <paramref name="resultText" />.
	/// </summary>
	public static ExpectationResult Copy<T>(
		ExpectationResult result,
		T value,
		Func<ExpectationResult, string>? expectationText = null,
		Func<Failure, string>? resultText = null)
	{
		expectationText ??= f => f.ExpectationText;
		if (result is not Failure failure)
		{
			return new Success<T>(value, expectationText.Invoke(result));
		}

		resultText ??= f => f.ResultText;
		return new Failure<T>(value, expectationText.Invoke(result), resultText.Invoke(failure));
	}

	/// <inheritdoc cref="object.ToString()" />
	public override string ToString()
		=> ExpectationText;

	/// <summary>
	///     Inverts the result.
	/// </summary>
	internal abstract ExpectationResult Invert(
		Func<ExpectationResult, string>? expectationText = null,
		Func<object?, string>? resultText = null);

	/// <summary>
	///     Updates the expectation text of the current <see cref="ExpectationResult" />.
	/// </summary>
	internal abstract ExpectationResult UpdateExpectationText(
		Func<ExpectationResult, string> expectationText);

	/// <summary>
	///     The actual value met the expectation.
	/// </summary>
	public class Success : ExpectationResult
	{
		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Success" />.
		/// </summary>
		public Success(string expectationText) : base(expectationText)
		{
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"SUCCEEDED {ExpectationText}";

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, Func{object?, string})" />
		internal override ExpectationResult Invert(
			Func<ExpectationResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Failure(expectationText.Invoke(this),
				resultText?.Invoke(null) ?? InvertDefaultResultText);
		}

		/// <inheritdoc />
		internal override ExpectationResult UpdateExpectationText(
			Func<ExpectationResult, string> expectationText)
			=> new Success(expectationText.Invoke(this));
	}

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
		public Success(T? value, string expectationText) : base(expectationText)
		{
			Value = value;
		}

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, Func{object?, string})" />
		internal override ExpectationResult Invert(
			Func<ExpectationResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Failure<T>(Value, expectationText.Invoke(this),
				resultText?.Invoke(Value) ?? InvertDefaultResultText);
		}

		/// <inheritdoc />
		internal override ExpectationResult UpdateExpectationText(
			Func<ExpectationResult, string> expectationText)
			=> new Success<T>(Value, expectationText.Invoke(this));
	}

	/// <summary>
	///     The actual value did not meet the expectation.
	/// </summary>
	public class Failure : ExpectationResult
	{
		/// <summary>
		///     A human-readable representation of the reason for the failure.
		/// </summary>
		public string ResultText { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Failure" />.
		/// </summary>
		public Failure(string expectationText, string resultText) : base(expectationText)
		{
			ResultText = resultText;
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"FAILED {ExpectationText}";

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, string)" />
		internal override ExpectationResult Invert(
			Func<ExpectationResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Success(expectationText.Invoke(this));
		}

		/// <inheritdoc />
		internal override ExpectationResult UpdateExpectationText(
			Func<ExpectationResult, string> expectationText)
			=> new Failure(expectationText.Invoke(this), ResultText);
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

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, string)" />
		internal override ExpectationResult Invert(
			Func<ExpectationResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Success<T>(Value, expectationText.Invoke(this));
		}

		/// <inheritdoc />
		internal override ExpectationResult UpdateExpectationText(
			Func<ExpectationResult, string> expectationText)
			=> new Failure<T>(Value, expectationText.Invoke(this), ResultText);
	}
}
