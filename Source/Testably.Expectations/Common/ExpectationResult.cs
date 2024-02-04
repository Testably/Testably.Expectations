namespace Testably.Expectations.Common;

public class ExpectationResult<TActual>
{
	private readonly string expectationText;
	private readonly bool _IsSuccess;

	public ExpectationResult(string expectationText, bool isSuccess)
	{
		this.expectationText = expectationText;
		_IsSuccess = isSuccess;
	}
	public bool IsSuccess()
	{
		return _IsSuccess;
	}

	public string CreateMessage(string? actualExpression, TActual? actual)
	{
		return $"Expected {actualExpression} {expectationText}, but found {actual}.";
	}
}
