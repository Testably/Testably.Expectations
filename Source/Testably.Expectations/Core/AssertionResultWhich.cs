﻿using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AssertionResult{TResult, TValue}" />, allows accessing underlying
///     properties with <see cref="Which{TProperty}" />.
/// </summary>
[StackTraceHidden]
public class AssertionResultWhich<TResult, TValue> : AssertionResult<TResult, TValue>
{
	private readonly IExpectationBuilder _expectationBuilder;

	/// <inheritdoc />
	internal AssertionResultWhich(IExpectationBuilder expectationBuilder, TValue assertion)
		: base(expectationBuilder, assertion)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Allows specifying expectations on a property of the current value.
	/// </summary>
	public AssertionResultWhich<TResult, TValue> Which<TProperty>(
		Expression<Func<TResult, TProperty?>> selector,
		Action<That<TProperty?>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue2 = "")
	{
		_expectationBuilder.Which<TResult, TProperty?>(
			PropertyAccessor<TResult, TProperty?>.FromExpression(selector),
			expectations,
			b => b.AppendMethod(nameof(Which), doNotPopulateThisValue1, doNotPopulateThisValue2));
		return this;
	}
}
