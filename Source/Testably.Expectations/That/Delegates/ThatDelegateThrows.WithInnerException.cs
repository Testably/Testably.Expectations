﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
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
				.WhichCast<TException, Exception?, Exception?,
					ThatExceptionShould<Exception?>>(
					PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
						"with an inner exception which should "),
					new ThatExceptionShould.CastException<Exception, Exception>(),
					expectations,
					e => new ThatExceptionShould<Exception?>(e),
					b => b.AppendMethod(nameof(WithInnerException),
						doNotPopulateThisValue),
					""),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception of type <typeparamref name="TException" />.
	/// </summary>
	public AndOrExpectationResult<TException, ThatDelegateThrows<TException>> WithInnerException()
		=> new(ExpectationBuilder.Add(
				new ThatExceptionShould.CastException<TException, Exception>(),
				b => b.AppendMethod(nameof(WithInnerException))),
			this);
}
