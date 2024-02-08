namespace Testably.Expectations.Core;

public class ExpectationResult<TActual>
{
	private readonly bool _isSuccess;
	private readonly string _expectationText;

	public ExpectationResult(string expectationText, bool isSuccess)
	{
		this._expectationText = expectationText;
		_isSuccess = isSuccess;
	}

	public string CreateMessage(string? actualExpression, TActual? actual)
	{
		return $"Expected {actualExpression} {_expectationText}, but found {actual}.";
	}

	public bool IsSuccess()
	{
		return _isSuccess;
	}
}
