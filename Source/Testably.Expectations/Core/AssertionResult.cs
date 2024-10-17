﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Testably.Expectations.Core;

public class AssertionResult<TResult, TValue> : AssertionResult<TResult>
{
	public TValue And => _assertion;
	private readonly TValue _assertion;

	internal AssertionResult(IExpectationBuilder expectationBuilder, TValue assertion) : base(
		expectationBuilder)
	{
		_assertion = assertion;
	}
}

public class AssertionResult<TResult>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal AssertionResult(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public TaskAwaiter<TResult> GetAwaiter()
	{
		Task<TResult>? result = GetResult();
		return result.GetAwaiter();
	}

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

	public TaskAwaiter GetAwaiter()
	{
		Task? result = GetResult();
		return result.GetAwaiter();
	}

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
