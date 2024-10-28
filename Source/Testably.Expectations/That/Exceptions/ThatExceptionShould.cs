using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

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
	public static ThatExceptionShould<TException> Should<TException>(
		this IExpectThat<TException> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		where TException : Exception?
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatExceptionShould<TException>(subject.ExpectationBuilder);
	}

	internal readonly struct HasMessageConstraint<T>(StringMatcher expected, string verb)
		: IConstraint<T>, IDelegateConstraint<DelegateSource.NoValue>
		where T : Exception?
	{
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			return IsMetBy(exception as T);
		}

		public ConstraintResult IsMetBy(T? actual)
		{
			if (expected.Matches(actual?.Message))
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				expected.GetExtendedFailure(actual?.Message));
		}

		public override string ToString()
			=> $"{verb} Message {expected.GetExpectation(GrammaticVoice.PassiveVoice)}";
	}

	internal readonly struct HasParamNameConstraint<T>(string expected, string verb)
		: IConstraint<T>,
			IDelegateConstraint<DelegateSource.NoValue>
		where T : ArgumentException?
	{
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			return IsMetBy(exception as T);
		}

		public ConstraintResult IsMetBy(T? actual)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure(ToString(),
					"found <null>");
			}

			if (actual.ParamName == expected)
			{
				return new ConstraintResult.Success<T?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"found ParamName {Formatter.Format(actual.ParamName)}");
		}

		public override string ToString()
			=> $"{verb} ParamName {Formatter.Format(expected)}";
	}

	internal readonly struct HasInnerExceptionConstraint<TInnerException>(string verb)
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
				"found <null>");
		}

		/// <inheritdoc />
		public ConstraintResult IsMetBy(DelegateSource.NoValue actual, Exception? exception)
		{
			return IsMetBy(exception);
		}

		public override string ToString()
			=> $"{verb} an inner {(typeof(TInnerException) == typeof(Exception) ? "exception" : Formatter.Format(typeof(TInnerException)))}";
	}

	internal class CastException<TBase, TTarget> : IConstraint<TBase?, TTarget?>
		where TBase : Exception?
		where TTarget : Exception?
	{
		#region IDelegateConstraint<TBase?> Members

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

/// <summary>
///     Base class for expectations on <typeparamref name="TException" />, containing an <see cref="ExpectationBuilder" />.
/// </summary>
public partial class ThatExceptionShould<TException>(IExpectationBuilder expectationBuilder)
	: IThat<TException>
	where TException : Exception?
{
	#region IThat<TException> Members

	/// <inheritdoc />
	public IExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;

	#endregion
}
