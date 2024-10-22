using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatExceptionExtensions
{
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
			=> $"has an inner {(typeof(TInnerException) == typeof(Exception) ? "exception" : Formatter.Format(typeof(TInnerException)))}";
	}
}
