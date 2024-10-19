﻿using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

[StackTraceHidden]
public class AssertionResult<TResult, TValue> : AssertionResult<TResult>
{
	public TValue And
	{
		get
		{
			_expectationBuilder.And(b => b.Append(".").Append(nameof(And)));
			return _assertion;
		}
	}
	public TValue Or
	{
		get
		{
			_expectationBuilder.Or(b => b.Append(".").Append(nameof(Or)));
			return _assertion;
		}
	}

	private readonly IExpectationBuilder _expectationBuilder;
	private readonly TValue _assertion;

	internal AssertionResult(IExpectationBuilder expectationBuilder, TValue assertion) : base(
		expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
		_assertion = assertion;
	}
}

[StackTraceHidden]
public class AssertionResultWhich<TResult, TValue> : AssertionResult<TResult, TValue>
{
	private readonly IExpectationBuilder _expectationBuilder;
	private readonly TValue _assertion;

	/// <inheritdoc />
	internal AssertionResultWhich(IExpectationBuilder expectationBuilder, TValue assertion)
		: base(expectationBuilder, assertion)
	{
		_expectationBuilder = expectationBuilder;
		_assertion = assertion;
	}

	public AssertionResultWhich<TResult, TValue> Which<TProperty>(Expression<Func<TResult, TProperty>> selector,
		Action<That<TProperty>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")] string doNotPopulateThisValue2 = "")
	{
		_expectationBuilder.Which<TResult, TProperty>(
			PropertyAccessor<TResult, TProperty>.FromExpression(selector),
			expectations,
			b => b.AppendMethod(nameof(Which), doNotPopulateThisValue1, doNotPopulateThisValue2));
		return this;
	}
}

[StackTraceHidden]
public class AssertionResult<TResult>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal AssertionResult(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	[StackTraceHidden]
	public TaskAwaiter<TResult> GetAwaiter()
	{
		Task<TResult>? result = GetResult();
		return result.GetAwaiter();
	}

	[StackTraceHidden]
	private async Task<TResult> GetResult()
	{
		ExpectationResult result = await _expectationBuilder.IsMet();

		if (result is ExpectationResult.Failure failure)
		{
			Fail.Test(_expectationBuilder.FailureMessageBuilder.FromFailure(failure));
		}
		else if (result is ExpectationResult.Success<TResult> success)
		{
			return success.Value;
		}

		throw new ExpectationException("You should not be here (with value)!");
	}
}

public class AssertionResult
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal AssertionResult(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	[StackTraceHidden]
	public TaskAwaiter GetAwaiter()
	{
		Task? result = GetResult();
		return result.GetAwaiter();
	}

	[StackTraceHidden]
	private async Task GetResult()
	{
		ExpectationResult result = await _expectationBuilder.IsMet();

		if (result is ExpectationResult.Failure failure)
		{
			Fail.Test(_expectationBuilder.FailureMessageBuilder.FromFailure(failure));
		}
		else if (result is ExpectationResult.Success success)
		{
			return;
		}

		throw new ExpectationException("You should not be here (without value)!");
	}
}
