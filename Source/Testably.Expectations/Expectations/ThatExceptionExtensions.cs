using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static class ThatExceptionExtensions
{
	/// <summary>
	///     Expect the <typeparamref type="TException" /> has a message equal to <paramref name="expected" />
	/// </summary>
	public static AssertionResult<TException, That<TException>> HasMessage<TException>(this That<TException> source,
	string expected, [CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : Exception
		=> new(source.ExpectationBuilder.Add(
				new HasMessageExpectation<TException>(expected),
				b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Expect the <typeparamref type="TException" /> has an inner exception.
	/// </summary>
	public static AssertionResult<TException, That<TException>> HasInnerException<TException>(this That<TException> source)
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionExpectation<Exception>(),
				b => b.AppendMethod(nameof(HasInnerException))),
			source);
	private readonly struct HasInnerExceptionExpectation<TInnerException>(
		Action<That<TInnerException>> assertions)
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
