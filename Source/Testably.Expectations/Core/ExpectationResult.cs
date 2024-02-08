/* Unmerged change from project 'Testably.Expectations (net6.0)'
Before:
namespace Testably.Expectations.Core.Internal;
After:
using Testably;
using Testably.Expectations;
using Testably.Expectations.Core;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Internal;
*/
namespace Testably.Expectations.Core;

internal class ExpectationResult
{
	public string ExpectationText { get; }
	public bool IsSuccess { get; }

	public ExpectationResult(string expectationText, bool isSuccess)
	{
		ExpectationText = expectationText;
		IsSuccess = isSuccess;
	}

	public static ExpectationResult Success(string expectationText)
	{
		return new ExpectationResult(expectationText, true);
	}
}

internal class ExpectationResult<T> : ExpectationResult
{
	public T? Value { get; }

	public ExpectationResult(T? value, string expectationText, bool isSuccess) : base(expectationText, isSuccess)
	{
		Value = value;
	}
}
