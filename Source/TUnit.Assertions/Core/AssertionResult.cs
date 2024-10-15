using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TUnit.Assertions.Core.Internal;

namespace TUnit.Assertions.Core;

public class AssertionResult<TResult, TAssertion>
{
	private readonly AssertionBuilder _assertionBuilder;
	private readonly Func<Task<TResult>> _value;
	private readonly TAssertion _assertion;

	internal AssertionResult(AssertionBuilder assertionBuilder, Func<Task<TResult>> value, TAssertion assertion)
	{
		_assertionBuilder = assertionBuilder;
		_value = value;
		_assertion = assertion;
	}

	public TAssertion And => _assertion;
	public TaskAwaiter<TResult> GetAwaiter()
	{
		_ = _assertionBuilder;
		return Task.FromResult(_value).GetAwaiter();
	}
}

public class AssertionResult<TResult>
{
	private readonly AssertionBuilder _assertionBuilder;
	private readonly Func<Task<TResult>> _value;

	internal AssertionResult(AssertionBuilder assertionBuilder, Func<Task<TResult>> value)
	{
		_assertionBuilder = assertionBuilder;
		_value = value;
	}

	public TaskAwaiter<TResult> GetAwaiter()
	{
		_ = _assertionBuilder;
		return Task.FromResult(_value).GetAwaiter();
	}
}
public class AssertionResult
{
	private readonly AssertionBuilder _assertionBuilder;

	internal AssertionResult(AssertionBuilder assertionBuilder)
	{
		_assertionBuilder = assertionBuilder;
	}

	public TaskAwaiter GetAwaiter()
	{
		_ = _assertionBuilder;
		return Task.CompletedTask.GetAwaiter();
	}
}

