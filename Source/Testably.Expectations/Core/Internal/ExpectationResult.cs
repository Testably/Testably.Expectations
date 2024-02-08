namespace Testably.Expectations.Core.Internal;

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
