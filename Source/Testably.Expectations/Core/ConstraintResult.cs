using System;
using System.Diagnostics.CodeAnalysis;

namespace Testably.Expectations.Core;

/// <summary>
///     The result of the check if an expectation is met.
/// </summary>
public abstract class ConstraintResult
{
	private const string InvertDefaultResultText = "it did";

	/// <summary>
	///     A human-readable representation of the expectation.
	/// </summary>
	public string ExpectationText { get; }

	/// <summary>
	///     Initializes a new instance of <see cref="ConstraintResult" />.
	/// </summary>
	protected ConstraintResult(string expectationText)
	{
		ExpectationText = expectationText;
	}

	/// <summary>
	///     Combines the result with the provided <paramref name="expectationText" /> and <paramref name="resultText" />.
	/// </summary>
	public abstract ConstraintResult CombineWith(string expectationText, string resultText);

	/// <summary>
	///     Inverts the result.
	/// </summary>
	public abstract ConstraintResult Invert(
		Func<ConstraintResult, string>? expectationText = null,
		Func<object?, string>? resultText = null);

	/// <summary>
	///     Updates the expectation text of the current <see cref="ConstraintResult" />.
	/// </summary>
	internal abstract ConstraintResult UpdateExpectationText(
		Func<ConstraintResult, string> expectationText);

	/// <summary>
	///     The actual value met the expectation.
	/// </summary>
	public class Success : ConstraintResult
	{
		/// <summary>
		///     Initializes a new instance of <see cref="ConstraintResult.Success" />.
		/// </summary>
		public Success(string expectationText) : base(expectationText)
		{
		}

		/// <inheritdoc cref="ConstraintResult.CombineWith(string, string)" />
		public override ConstraintResult CombineWith(string expectationText, string resultText)
		{
			return new Success(expectationText);
		}

		/// <inheritdoc cref="ConstraintResult.Invert(Func{ConstraintResult, string}, Func{object?, string})" />
		public override ConstraintResult Invert(
			Func<ConstraintResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Failure(expectationText.Invoke(this),
				resultText?.Invoke(null) ?? InvertDefaultResultText);
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"SUCCEEDED {ExpectationText}";

		internal virtual bool TryGetValue<TValue>([NotNullWhen(true)] out TValue? value)
		{
			value = default;
			return false;
		}

		/// <inheritdoc />
		internal override ConstraintResult UpdateExpectationText(
			Func<ConstraintResult, string> expectationText)
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
		///     Initializes a new instance of <see cref="ConstraintResult.Success{T}" />.
		/// </summary>
		public Success(T value, string expectationText) : base(expectationText)
		{
			Value = value;
		}

		/// <inheritdoc cref="ConstraintResult.CombineWith(string, string)" />
		public override ConstraintResult CombineWith(string expectationText, string resultText)
		{
			return new Success<T>(Value, expectationText);
		}

		/// <inheritdoc cref="ConstraintResult.Invert(Func{ConstraintResult, string}, Func{object?, string})" />
		public override ConstraintResult Invert(
			Func<ConstraintResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Failure<T>(Value, expectationText.Invoke(this),
				resultText?.Invoke(Value) ?? InvertDefaultResultText);
		}

		internal override bool TryGetValue<TValue>([NotNullWhen(true)] out TValue? value)
			where TValue : default
		{
			if (Value is TValue v)
			{
				value = v;
				return true;
			}

			value = default;
			return false;
		}

		/// <inheritdoc />
		internal override ConstraintResult UpdateExpectationText(
			Func<ConstraintResult, string> expectationText)
			=> new Success<T>(Value, expectationText.Invoke(this));
	}

	/// <summary>
	///     The actual value did not meet the expectation.
	/// </summary>
	public class Failure : ConstraintResult
	{
		/// <summary>
		///     A human-readable representation of the reason for the failure.
		/// </summary>
		public string ResultText { get; }

		/// <summary>
		///     Initializes a new instance of <see cref="ConstraintResult.Failure" />.
		/// </summary>
		public Failure(string expectationText, string resultText) : base(expectationText)
		{
			ResultText = resultText;
		}

		/// <inheritdoc cref="ConstraintResult.CombineWith(string, string)" />
		public override ConstraintResult CombineWith(string expectationText, string resultText)
		{
			return new Failure(expectationText, resultText);
		}

		/// <inheritdoc cref="ConstraintResult.Invert(Func{ConstraintResult, string}, Func{object?, string})" />
		public override ConstraintResult Invert(
			Func<ConstraintResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Success(expectationText.Invoke(this));
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"FAILED {ExpectationText}";

		/// <inheritdoc />
		internal override ConstraintResult UpdateExpectationText(
			Func<ConstraintResult, string> expectationText)
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
		///     Initializes a new instance of <see cref="ConstraintResult.Failure{T}" />.
		/// </summary>
		public Failure(T value, string expectationText, string resultText) : base(expectationText,
			resultText)
		{
			Value = value;
		}

		/// <inheritdoc cref="ConstraintResult.CombineWith(string, string)" />
		public override ConstraintResult CombineWith(string expectationText, string resultText)
		{
			return new Failure<T>(Value, expectationText, resultText);
		}

		/// <inheritdoc cref="ConstraintResult.Invert(Func{ConstraintResult, string}, Func{object?, string})" />
		public override ConstraintResult Invert(
			Func<ConstraintResult, string>? expectationText = null,
			Func<object?, string>? resultText = null)
		{
			expectationText ??= f => f.ExpectationText;
			return new Success<T>(Value, expectationText.Invoke(this));
		}

		/// <inheritdoc />
		internal override ConstraintResult UpdateExpectationText(
			Func<ConstraintResult, string> expectationText)
			=> new Failure<T>(Value, expectationText.Invoke(this), ResultText);
	}
}
