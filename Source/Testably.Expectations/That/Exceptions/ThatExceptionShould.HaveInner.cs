using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public partial class ThatExceptionShould<TException>
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TInnerException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrResult<TException, ThatExceptionShould<TException>> HaveInner<
		TInnerException>(
		Action<ThatExceptionShould<TInnerException?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		where TInnerException : Exception?
		=> new(ExpectationBuilder
				.ForProperty<Exception, Exception?>(e => e.InnerException,
					$"have an inner {typeof(TInnerException).Name} which should ")
				.Validate(new ThatExceptionShould.ExceptionCastConstraint<TInnerException>())
				.AddExpectations(e => expectations(new ThatExceptionShould<TInnerException?>(e)))
				.AppendGenericMethodStatement<TInnerException>(nameof(HaveInner),
					doNotPopulateThisValue),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public AndOrResult<TException, ThatExceptionShould<TException>> HaveInner<
		TInnerException>()
		where TInnerException : Exception?
		=> new(ExpectationBuilder
				.AddConstraint(
					new ThatExceptionShould.HasInnerExceptionValueConstraint<TInnerException>(
						"have"))
				.AppendGenericMethodStatement<TInnerException>(nameof(HaveInner)),
			this);
}
