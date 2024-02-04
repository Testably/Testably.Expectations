namespace Testably.Expectations.Common;

public class ConstraintResult<TResult>
{
	public ConstraintResult(bool isSuccess, TResult value)
	{
		IsSuccess = isSuccess;
		Value = value;
	}

	public bool IsSuccess { get; }
	public TResult Value { get; }
}

public class ConstraintResult
{
	public ConstraintResult(bool isSuccess, object? value)
	{
		IsSuccess = isSuccess;
		Value = value;
	}

	public bool IsSuccess { get; }
	public object? Value { get; }
}
