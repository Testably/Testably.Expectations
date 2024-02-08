namespace Testably.Expectations.Core;

public class ConstraintResult<TResult>
{
	public bool IsSuccess { get; }
	public TResult Value { get; }

	public ConstraintResult(bool isSuccess, TResult value)
	{
		IsSuccess = isSuccess;
		Value = value;
	}
}

public class ConstraintResult
{
	public bool IsSuccess { get; }
	public object? Value { get; }

	public ConstraintResult(bool isSuccess, object? value)
	{
		IsSuccess = isSuccess;
		Value = value;
	}
}
