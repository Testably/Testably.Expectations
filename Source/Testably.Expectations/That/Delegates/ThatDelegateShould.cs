using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.That.Delegates;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on delegate values.
/// </summary>
public static partial class ThatDelegateShould
{
	private static readonly string DoesNotThrowExpectation = "not throw any exception";

	/// <summary>
	///     Start expectations for the current <see cref="Action" /> <paramref name="subject" />.
	/// </summary>
	public static ThatDelegate.WithoutValue Should(
		this IExpectSubject<ThatDelegate.WithoutValue> subject)
		=> new(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="Func{TValue}" /> <paramref name="subject" />.
	/// </summary>
	public static ThatDelegate.WithValue<TValue> Should<TValue>(
		this IExpectSubject<ThatDelegate.WithValue<TValue>> subject)
		=> new(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	private static ConstraintResult DoesNotThrowResult<TException>(Exception? exception)
		where TException : Exception?
	{
		if (exception is not null)
		{
			return new ConstraintResult.Failure<Exception?>(exception, DoesNotThrowExpectation,
				$"it did throw {exception.FormatForMessage()}", true);
		}

		return new ConstraintResult.Success<TException?>(default, DoesNotThrowExpectation, true);
	}

	private readonly struct ThrowsCastConstraint<TException>(ThrowsOption throwOptions)
		: ICastConstraint<DelegateValue, TException?>
		where TException : Exception
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(Exception? exception)
		{
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowResult<TException>(exception);
			}

			if (exception is TException typedException)
			{
				return new ConstraintResult.Success<TException?>(typedException, ToString());
			}

			if (exception is null)
			{
				return new ConstraintResult.Failure<TException?>(null, ToString(), "it did not");
			}

			return new ConstraintResult.Failure<TException?>(null, ToString(),
				$"it did throw {exception.FormatForMessage()}");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateValue? value)
			=> IsMetBy(value?.Exception);

		public override string ToString()
		{
			if (!throwOptions.DoCheckThrow)
			{
				return DoesNotThrowExpectation;
			}

			return $"throw {typeof(TException).Name.PrependAOrAn()}";
		}
	}
}
