using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation without an underlying value.
/// </summary>
[StackTraceHidden]
public class ExpectationResult(ExpectationBuilder expectationBuilder)
{
	/// <summary>
	///     Provide a <paramref name="reason" /> explaining why the constraint is needed.<br />
	///     If the phrase does not start with the word <i>because</i>, it is prepended automatically.
	/// </summary>
	public ExpectationResult Because(string reason)
	{
		expectationBuilder.AddReason(reason);
		return this;
	}

	/// <summary>
	///     By awaiting the result, the expectations are verified.
	///     <para />
	///     Will throw an exception, when the expectations are not met.
	/// </summary>
	public TaskAwaiter GetAwaiter()
	{
		Task result = GetResult();
		return result.GetAwaiter();
	}

	private async Task GetResult()
	{
		ConstraintResult result = await expectationBuilder.IsMet();

		if (result is ConstraintResult.Failure failure)
		{
			Fail.Test(expectationBuilder.FailureMessageBuilder.FromFailure(failure));
		}
		else if (result is ConstraintResult.Success)
		{
			return;
		}

		throw new FailException("You should not be here (without value)!");
	}
}

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
/// </summary>
public class ExpectationResult<TResult>(ExpectationBuilder expectationBuilder)
	: ExpectationResult<TResult, ExpectationResult<TResult>>(expectationBuilder);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
/// </summary>
[StackTraceHidden]
public class ExpectationResult<TResult, TSelf>(ExpectationBuilder expectationBuilder)
	where TSelf : ExpectationResult<TResult, TSelf>
{
	/// <summary>
	///     Provide a <paramref name="reason" /> explaining why the constraint is needed.<br />
	///     If the phrase does not start with the word <i>because</i>, it is prepended automatically.
	/// </summary>
	public TSelf Because(string reason,
		[CallerArgumentExpression("reason")] string doNotPopulateThisValue = "")
	{
		expectationBuilder
			.AppendMethodStatement(nameof(Because), doNotPopulateThisValue)
			.AddReason(reason);
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
		Task<TResult> result = GetResult();
		return result.GetAwaiter();
	}

	[StackTraceHidden]
	private async Task<TResult> GetResult()
	{
		ConstraintResult result = await expectationBuilder.IsMet();

		if (result is ConstraintResult.Failure failure)
		{
			Fail.Test(expectationBuilder.FailureMessageBuilder.FromFailure(failure));
		}
		else if (result is ConstraintResult.Success<TResult> matchingSuccess)
		{
			return matchingSuccess.Value;
		}
		else if (result is ConstraintResult.Success success &&
		         success.TryGetValue(out TResult? value))
		{
			return value;
		}

		throw new FailException("You should not be here (with value)!");
	}
}
