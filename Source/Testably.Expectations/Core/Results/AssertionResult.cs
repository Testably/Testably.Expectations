using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Results;

/// <summary>
///     The result of an assertion without an underlying value.
/// </summary>
public class AssertionResult(IExpectationBuilder expectationBuilder)
{
	/// <summary>
	///     Provide a <paramref name="reason" /> explaining why the assertion is needed.<br />
	///     If the phrase does not start with the word <i>because</i>, it is prepended automatically.
	/// </summary>
	public AssertionResult Because(string reason)
	{
		expectationBuilder.AddReason(reason);
		return this;
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
		ExpectationResult result = await expectationBuilder.IsMet();

		if (result is ExpectationResult.Failure failure)
		{
			Fail.Test(expectationBuilder.FailureMessageBuilder.FromFailure(failure));
		}
		else if (result is ExpectationResult.Success)
		{
			return;
		}

		throw new ExpectationException("You should not be here (without value)!");
	}
}

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
/// </summary>
[StackTraceHidden]
public class AssertionResult<TResult>(IExpectationBuilder expectationBuilder)
	: AssertionResult<TResult, AssertionResult<TResult>>(expectationBuilder);

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
/// </summary>
[StackTraceHidden]
public class AssertionResult<TResult, TSelf>(IExpectationBuilder expectationBuilder)
	where TSelf : AssertionResult<TResult, TSelf>
{
	/// <summary>
	///     Provide a <paramref name="reason" /> explaining why the assertion is needed.<br />
	///     If the phrase does not start with the word <i>because</i>, it is prepended automatically.
	/// </summary>
	public TSelf Because(string reason)
	{
		expectationBuilder.AddReason(reason);
		return (TSelf)this;
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
		ExpectationResult result = await expectationBuilder.IsMet();

		if (result is ExpectationResult.Failure failure)
		{
			Fail.Test(expectationBuilder.FailureMessageBuilder.FromFailure(failure));
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
