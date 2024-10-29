using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations.That.Delegates;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies that the thrown exception has an inner exception which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException>> WithInnerException(
		Action<ThatExceptionShould<Exception?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder
				.ForProperty<Exception, Exception?>(e => e.InnerException,
					"with an inner exception which should ")
				.Validate(new ThatExceptionShould.CastException<Exception>())
				.AddExpectations(e => expectations(new ThatExceptionShould<Exception?>(e)))
				.AppendMethodStatement(nameof(WithInnerException),
					doNotPopulateThisValue),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException>> WithInnerException()
		=> new(ExpectationBuilder
				.AddConstraint(
					new ThatExceptionShould.HasInnerExceptionValueConstraint<Exception>("with"))
				.AppendMethodStatement(nameof(WithInnerException)),
			this);
}
