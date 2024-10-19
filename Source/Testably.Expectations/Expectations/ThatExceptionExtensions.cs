using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using static Testably.Expectations.Core.Sources.DelegateSource;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static class ThatExceptionExtensions
{
	/// <summary>
	///     Verifies that the actual exception has a message equal to <paramref name="expected" />
	/// </summary>
	public static AssertionResult<TException, That<TException>> HasMessage<TException>(this That<TException> source,
	string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : Exception
		=> new(source.ExpectationBuilder.Add(
				new HasMessageExpectation<TException>(expected),
				b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception.
	/// </summary>
	public static AssertionResult<Exception, That<Exception>> HasInnerException(this That<Exception> source)
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionExpectation<Exception>(),
				b => b.AppendMethod(nameof(HasInnerException))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TInnerException"/>.
	/// </summary>
	public static AssertionResult<Exception, That<Exception>> HasInner<TInnerException>(this That<Exception> source)
		where TInnerException : Exception
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionExpectation<TInnerException>(),
				b => b.AppendGenericMethod<TInnerException>(nameof(HasInner))),
			source);

	private readonly struct HasInnerExceptionExpectation<TInnerException>
		: IExpectation<Exception?>,
			IDelegateExpectation<DelegateSource.NoValue>
		where TInnerException : Exception
	{
		/// <inheritdoc />
		public ExpectationResult IsMetBy(Exception? actual)
		{
			var innerException = actual?.InnerException;
			if (actual?.InnerException is TInnerException exception)
			{
				return new ExpectationResult.Success<Exception?>(exception, ToString());
			}

			if (innerException is not null)
			{
				return new ExpectationResult.Failure<Exception?>(innerException, ToString(), $"found {innerException.GetType().Name.PrependAOrAn()}:{Environment.NewLine}{innerException.Message.Indent("  ")}");
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
				$"found {Formatter.Format(actual?.Message, FormattingOptions.SingleLine)} which {new StringDifference(actual?.Message, expected)}");
		}

		public override string ToString()
			=> $"has Message equal to {Formatter.Format(expected, FormattingOptions.SingleLine)}";
	}
}
