using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;
using Testably.Expectations.Core.Sources;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public static class ThatExceptionExtensions
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AssertionResultAndOr<Exception, That<Exception?>> HasInner<TException>(
		this That<Exception?> source,
		Action<That<TException?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		where TException : Exception
		=> new(source.ExpectationBuilder.WhichCast<Exception, Exception?, TException?>(
				PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
					$"has an inner {typeof(TException).Name} which "),
				new CastException<Exception, TException>(),
				expectations,
				b => b.AppendGenericMethod<TException>(nameof(HasInner), doNotPopulateThisValue),
				""),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public static AssertionResultAndOr<Exception, That<Exception?>> HasInner<TException>(
		this That<Exception?> source)
		where TException : Exception
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionExpectation<TException>(),
				b => b.AppendGenericMethod<TException>(nameof(HasInner))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception.
	/// </summary>
	public static AssertionResultAndOr<Exception, That<Exception?>> HasInnerException(
		this That<Exception?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionExpectation<Exception>(),
				b => b.AppendMethod(nameof(HasInnerException))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception which satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AssertionResultAndOr<Exception, That<Exception?>> HasInnerException(
		this That<Exception?> source,
		Action<That<Exception?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Which<Exception, Exception?>(
				PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
					"has an inner exception which "),
				expectations,
				b => b.AppendMethod(nameof(HasInnerException), doNotPopulateThisValue),
				whichTextSeparator: ""),
			source);

	/// <summary>
	///     Verifies that the actual exception has a message equal to <paramref name="expected" />
	/// </summary>
	public static MatcherAssertionResult<TException, That<TException?>> HasMessage<TException>(
		this That<TException?> source,
		StringMatcher expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : Exception
		=> new(source.ExpectationBuilder.Add(
				new HasMessageExpectation<TException>(expected),
				b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			source,
			expected);

	private class CastException<TBase, TTarget> : IExpectation<TBase?, TTarget?>
		where TBase : Exception
		where TTarget : Exception
	{
		#region IExpectation<TBase?,TTarget?> Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(TBase? actual, Exception? exception)
		{
			if (actual is TTarget casted)
			{
				return new ExpectationResult.Success<TTarget>(casted, "");
			}

			return new ExpectationResult.Failure<Exception?>(actual, "",
				actual == null
					? "found <null>"
					: $"found {actual.GetType().Name.PrependAOrAn()}:{Environment.NewLine}{actual.Message.Indent()}");
		}

		#endregion
	}

	private readonly struct HasInnerExceptionExpectation<TInnerException>
		: IExpectation<Exception?>,
			IDelegateExpectation<DelegateSource.NoValue>
		where TInnerException : Exception
	{
		/// <inheritdoc />
		public ExpectationResult IsMetBy(Exception? actual)
		{
			Exception? innerException = actual?.InnerException;
			if (actual?.InnerException is TInnerException exception)
			{
				return new ExpectationResult.Success<Exception?>(exception, ToString());
			}

			if (innerException is not null)
			{
				return new ExpectationResult.Failure<Exception?>(innerException, ToString(),
					$"found {innerException.GetType().Name.PrependAOrAn()}:{Environment.NewLine}{innerException.Message.Indent()}");
			}

			return new ExpectationResult.Failure(ToString(),
				"it did not");
		}

		/// <inheritdoc />
		public ExpectationResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception);
		}

		public override string ToString()
			=> $"has an inner {(typeof(TInnerException) == typeof(Exception) ? "exception" : Formatter.Format(typeof(TInnerException)))}";
	}

	private readonly struct HasMessageExpectation<T>(StringMatcher expected) : IExpectation<T>,
		IDelegateExpectation<DelegateSource.NoValue>
		where T : Exception
	{
		public ExpectationResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ExpectationResult IsMetBy(T? actual)
		{
			if (expected.Matches(actual?.Message))
			{
				return new ExpectationResult.Success<T?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				expected.GetExtendedFailure(actual?.Message));
		}

		public override string ToString()
			=> $"has Message {expected.GetExpectation(GrammaticVoice.PassiveVoice)}";
	}

	private readonly struct HasMessageMatchingExpectation<T>(StringMatcher pattern)
		: IExpectation<T>,
			IDelegateExpectation<DelegateSource.NoValue>
		where T : Exception
	{
		public ExpectationResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception as T);
		}

		public ExpectationResult IsMetBy(T? actual)
		{
			if (pattern.Matches(actual?.Message))
			{
				return new ExpectationResult.Success<T?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual?.Message, FormattingOptions.SingleLine)}");
		}

		public override string ToString()
			=> $"has Message matching {Formatter.Format(pattern, FormattingOptions.SingleLine)}";
	}
}
