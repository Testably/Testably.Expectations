using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public static partial class ThatExceptionExtensions
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AndOrExpectationResult<Exception, That<Exception?>> HasInner<TException>(
		this That<Exception?> source,
		Action<That<TException?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		where TException : Exception?
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
	public static AndOrExpectationResult<Exception, That<Exception?>> HasInner<TException>(
		this That<Exception?> source)
		where TException : Exception?
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionConstraint<TException>(),
				b => b.AppendGenericMethod<TException>(nameof(HasInner))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception.
	/// </summary>
	public static AndOrExpectationResult<Exception, That<Exception?>> HasInnerException(
		this That<Exception?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasInnerExceptionConstraint<Exception>(),
				b => b.AppendMethod(nameof(HasInnerException))),
			source);

	/// <summary>
	///     Verifies that the actual exception has an inner exception which satisfies the <paramref name="expectations" />.
	/// </summary>
	public static AndOrExpectationResult<Exception?, That<Exception?>> HasInnerException(
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
	public static StringMatcherExpectationResult<TException, That<TException>> HasMessage<TException>(
		this That<TException> source,
		StringMatcher expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : Exception?
		=> new(source.ExpectationBuilder.Add(
				new HasMessageConstraint<TException>(expected),
				b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			source,
			expected);

	/// <summary>
	///     Verifies that the actual exception has a message equal to <paramref name="expected" />
	/// </summary>
	public static AndOrExpectationResult<TException, That<TException>> HasParamName<TException>(
		this That<TException> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TException : ArgumentException?
		=> new(source.ExpectationBuilder.Add(
				new HasParamNameConstraint<TException>(expected),
				b => b.AppendMethod(nameof(HasMessage), doNotPopulateThisValue)),
			source);

	private class CastException<TBase, TTarget> : IConstraint<TBase?, TTarget?>
		where TBase : Exception
		where TTarget : Exception?
	{
		#region IExpectation<TBase?,TTarget?> Members

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
