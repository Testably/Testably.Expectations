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

	public abstract ExpectationResult CombineWith(string expectationText, string resultText);

	/// <summary>
	///     Inverts the result.
	/// </summary>
	public abstract ExpectationResult Invert(
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

		public override ExpectationResult CombineWith(string expectationText, string resultText)
		{
			return new Success(expectationText);
		}

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, Func{object?, string})" />
		public override ExpectationResult Invert(
			Func<ExpectationResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Failure(expectationText.Invoke(this),
				resultText?.Invoke(null) ?? InvertDefaultResultText);
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"SUCCEEDED {ExpectationText}";

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
		public T Value { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Success{T}" />.
		/// </summary>
		public Success(T value, string expectationText) : base(expectationText)
		{
			Value = value;
		}

		public override ExpectationResult CombineWith(string expectationText, string resultText)
		{
			return new Success<T>(Value, expectationText);
		}

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, Func{object?, string})" />
		public override ExpectationResult Invert(
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

		public override ExpectationResult CombineWith(string expectationText, string resultText)
		{
			return new Failure(expectationText, resultText);
		}

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, Func{object?, string})" />
		public override ExpectationResult Invert(
			Func<ExpectationResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Success(expectationText.Invoke(this));
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"FAILED {ExpectationText}";

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
		public T Value { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ExpectationResult.Failure{T}" />.
		/// </summary>
		public Failure(T value, string expectationText, string resultText) : base(expectationText,
			resultText)
		{
			Value = value;
		}

		public override ExpectationResult CombineWith(string expectationText, string resultText)
		{
			return new Failure<T>(Value, expectationText, resultText);
		}

		/// <inheritdoc cref="ExpectationResult.Invert(Func{ExpectationResult, string}, Func{object?, string})" />
		public override ExpectationResult Invert(
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
