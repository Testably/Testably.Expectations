using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations.That.Delegates;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies that the thrown exception has an inner exception of type <typeparamref name="TInnerException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException>>
		WithInner<TInnerException>(
			Action<ThatExceptionShould<TInnerException?>> expectations,
			[CallerArgumentExpression("expectations")]
			string doNotPopulateThisValue = "")
		where TInnerException : Exception
		=> new(ExpectationBuilder
				.ForProperty<Exception, Exception?>(e => e.InnerException,
					$"with an inner {typeof(TInnerException).Name} which should ")
				.Validate(new ThatExceptionShould.CastException<TInnerException>())
				.AddExpectations(e => expectations(new ThatExceptionShould<TInnerException?>(e)))
				.AppendGenericMethodStatement<TInnerException>(nameof(WithInner),
					doNotPopulateThisValue),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException>> WithInner<
		TInnerException>()
		where TInnerException : Exception?
		=> new(ExpectationBuilder
				.AddConstraint(
					new ThatExceptionShould.HasInnerExceptionValueConstraint<TInnerException>(
						"with"))
				.AppendGenericMethodStatement<TInnerException>(nameof(WithInner)),
			this);
}
