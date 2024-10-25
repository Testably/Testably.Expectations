using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public static partial class ThatExceptionShould
{
	/// <summary>
	///     Start expectations for the current <see cref="Exception" /> <paramref name="subject" />.
	/// </summary>
	public static That<Exception?> Should(this IExpectThat<Exception?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<Exception?>(subject.ExpectationBuilder);
	}

	private readonly struct HasInnerExceptionConstraint<TInnerException>
		: IConstraint<Exception?>,
			IDelegateConstraint<DelegateSource.NoValue>
		where TInnerException : Exception?
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(Exception? actual)
		{
			Exception? innerException = actual?.InnerException;
			if (actual?.InnerException is TInnerException exception)
			{
				return new ConstraintResult.Success<Exception?>(exception, ToString());
			}

			if (innerException is not null)
			{
				return new ConstraintResult.Failure<Exception?>(innerException, ToString(),
					$"found {innerException.FormatForMessage()}");
			}

			return new ConstraintResult.Failure(ToString(),
				"it did not");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(SourceValue<DelegateSource.NoValue> value)
		{
			return IsMetBy(value.Exception);
		}

		public override string ToString()
			=> $"have an inner {(typeof(TInnerException) == typeof(Exception) ? "exception" : Formatter.Format(typeof(TInnerException)))}";
	}

	private class CastException<TBase, TTarget> : IConstraint<TBase?, TTarget?>
		where TBase : Exception
		where TTarget : Exception?
	{
		#region IConstraint<TBase?,TTarget?> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(TBase? actual, Exception? exception)
		{
			if (actual is TTarget casted)
			{
				return new ConstraintResult.Success<TTarget>(casted, "");
			}

			return new ConstraintResult.Failure<Exception?>(actual, "",
				actual == null
					? "found <null>"
					: $"found {actual.FormatForMessage()}");
		}

		#endregion
	}
}
