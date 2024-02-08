namespace Testably.Expectations.Constraints;

public class ConstraintResult<TResult> : ConstraintResult
{
	public TResult? Value { get; }

	public ConstraintResult(bool isSuccess, TResult? value) : base(isSuccess)
	{
		Value = value;
	}

	public static ConstraintResult<TResult> Success(TResult value)
	{
		return new ConstraintResult<TResult>(true, value);
	}

	public static ConstraintResult<TResult> Failure(TResult? value = default)
	{
		return new ConstraintResult<TResult>(false, value);
	}
}

public class ConstraintResult
{
	public bool IsSuccess { get; }

	public ConstraintResult(bool isSuccess)
	{
		IsSuccess = isSuccess;
	}
}
