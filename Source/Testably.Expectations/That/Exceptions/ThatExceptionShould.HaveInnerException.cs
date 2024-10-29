﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Exception" /> values.
/// </summary>
public partial class ThatExceptionShould<TException>
{
	/// <summary>
	///     Verifies that the actual exception has an inner exception.
	/// </summary>
	public AndOrExpectationResult<TException, ThatExceptionShould<TException>> HaveInnerException()
		=> new(ExpectationBuilder
				.AddConstraint(
					new ThatExceptionShould.HasInnerExceptionValueConstraint<TException>("have"))
				.AppendMethodStatement(nameof(HaveInnerException)),
			this);

	/// <summary>
	///     Verifies that the actual exception has an inner exception which satisfies the <paramref name="expectations" />.
	/// </summary>
	public AndOrExpectationResult<TException?, ThatExceptionShould<TException>> HaveInnerException(
		Action<ThatExceptionShould<Exception?>> expectations,
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue = "")
		=> new(ExpectationBuilder.Which<Exception, Exception?, ThatExceptionShould<Exception?>>(
					PropertyAccessor<Exception, Exception?>.FromFunc(e => e.Value?.InnerException,
						"have an inner exception which should "),
					expectations,
					e => new ThatExceptionShould<Exception?>(e),
					b => b.AppendMethod(nameof(HaveInnerException), doNotPopulateThisValue),
			whichTextSeparator: ""),
	this);
}
