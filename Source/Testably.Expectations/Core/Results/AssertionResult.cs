using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Results;

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple assertions with <see cref="And" /> and <see cref="Or" />.
/// </summary>
[StackTraceHidden]
public class AssertionResult<TResult, TValue> : AssertionResult<TResult>
{
	/// <summary>
	///     Combine multiple expectations with AND
	/// </summary>
	public TValue And
	{
		get
		{
			_expectationBuilder.And(b => b.Append(".").Append(nameof(And)));
			return _assertion;
		}
	}

	/// <summary>
	///     Combine multiple expectations with OR
	/// </summary>
	public TValue Or
	{
		get
		{
			_expectationBuilder.Or(b => b.Append(".").Append(nameof(Or)));
			return _assertion;
		}
	}

	private readonly TValue _assertion;

	private readonly IExpectationBuilder _expectationBuilder;

	internal AssertionResult(IExpectationBuilder expectationBuilder, TValue assertion) : base(
		expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
		_assertion = assertion;
	}
}

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
/// </summary>
[StackTraceHidden]
public class AssertionResult<TResult>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal AssertionResult(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     By awaiting the result, the expectations are verified.
	///     <para />
	///     Will throw an exception, when the expectations are not met.<br />
	///     Otherwise, it will return the <typeparamref name="TResult" />.
	/// </summary>
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
		else if (result is ExpectationResult.Success<TResult> matchingSuccess)
		{
			return matchingSuccess.Value;
		}
		else if (result is ExpectationResult.Success success &&
				 success.TryGetValue(out TResult? value))
		{
			return value;
		}

		throw new ExpectationException("You should not be here (with value)!");
	}
}

/// <summary>
///     The result of an assertion without an underlying value.
/// </summary>
public class AssertionResult
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal AssertionResult(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     By awaiting the result, the expectations are verified.
	///     <para />
	///     Will throw an exception, when the expectations are not met.
	/// </summary>
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
		else if (result is ExpectationResult.Success)
		{
			return;
		}

		throw new ExpectationException("You should not be here (without value)!");
	}
}
