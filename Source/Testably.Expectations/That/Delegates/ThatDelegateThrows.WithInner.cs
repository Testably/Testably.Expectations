using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

namespace Testably.Expectations.That.Delegates;

public partial class ThatDelegateThrows<TException>
{
	/// <summary>
	///     Verifies that the thrown exception has an inner exception of type <typeparamref name="TInnerException" /> which
	///     satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException?>>
		WithInner<TInnerException>(
			Action<ThatExceptionShould<TInnerException?>> expectations,
			[CallerArgumentExpression("expectations")]
			string doNotPopulateThisValue = "")
		where TInnerException : Exception?
		=> new(ExpectationBuilder
				.WhichCast<Exception, Exception?, TInnerException?,
					ThatExceptionShould<TInnerException?>>(
					PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
						$"have an inner {typeof(TInnerException).Name} which should "),
					new ThatExceptionShould.CastException<Exception, TInnerException>(),
					expectations,
					e => new ThatExceptionShould<TInnerException?>(e),
					b => b.AppendGenericMethod<TInnerException>(nameof(WithInner),
						doNotPopulateThisValue),
					""),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException?>> WithInner<
		TInnerException>()
		where TInnerException : Exception?
		=> new(ExpectationBuilder.Add(
				new ThatExceptionShould.CastException<Exception, TInnerException>(),
				b => b.AppendGenericMethod<TInnerException>(nameof(WithInner))),
			this);
}
