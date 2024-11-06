using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

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
		this IExpectSubject<TException> subject)
		where TException : Exception?
		=> new(subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should))).ExpectationBuilder);

	internal readonly struct HasMessageValueConstraint<TException>(
		StringMatcher expected,
		string verb)
		: IValueConstraint<Exception?>
		where TException : Exception?
	{
		public ConstraintResult IsMetBy(Exception? actual)
		{
			if (expected.Matches(actual?.Message))
			{
				return new ConstraintResult.Success<TException?>(actual as TException, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				expected.GetExtendedFailure(actual?.Message));
		}

		public override string ToString()
			=> $"{verb} Message {expected.GetExpectation(StringMatcher.GrammaticVoice.PassiveVoice)}";
	}

	internal readonly struct HasParamNameValueConstraint<TArgumentException>(
		string expected,
		string verb)
		: IValueConstraint<Exception?>
		where TArgumentException : ArgumentException?
	{
		public ConstraintResult IsMetBy(Exception? actual)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure(ToString(),
					"found <null>");
			}

			if (actual is TArgumentException argumentException)
			{
				if (argumentException.ParamName == expected)
				{
					return new ConstraintResult.Success<TArgumentException?>(argumentException,
						ToString());
				}

				return new ConstraintResult.Failure(ToString(),
					$"found ParamName {Formatter.Format(argumentException.ParamName)}");
			}

			return new ConstraintResult.Failure(ToString(),
				$"found {actual.GetType().Name.PrependAOrAn()}");
		}

		public override string ToString()
			=> $"{verb} ParamName {Formatter.Format(expected)}";
	}

	internal readonly struct HasInnerExceptionValueConstraint<TInnerException>(string verb)
		: IValueConstraint<Exception?>
		where TInnerException : Exception?
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(Exception? actual)
		{
			Exception? innerException = actual?.InnerException;
			if (actual?.InnerException is TInnerException)
			{
				return new ConstraintResult.Success<Exception?>(actual, ToString());
			}

			if (innerException is not null)
			{
				return new ConstraintResult.Failure<Exception?>(actual, ToString(),
					$"found {innerException.FormatForMessage()}");
			}

			return new ConstraintResult.Failure<Exception?>(actual, ToString(),
				"found <null>");
		}

		public override string ToString()
			=> $"{verb} an inner {(typeof(TInnerException) == typeof(Exception) ? "exception" : Formatter.Format(typeof(TInnerException)))}";
	}

	internal class ExceptionCastConstraint<TTarget> : ICastConstraint<Exception?, TTarget>
		where TTarget : Exception?
	{
		#region ICastConstraint<Exception?,TTarget> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(Exception? actual)
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
public partial class ThatExceptionShould<TException>(ExpectationBuilder expectationBuilder)
	: IThat<TException>
	where TException : Exception?
{
	#region IThat<TException> Members

	/// <inheritdoc />
	public ExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;

	#endregion
}
