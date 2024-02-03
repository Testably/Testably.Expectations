namespace Testably.Expectations.Common;

public class ConstraintResult<TActual>
{
	private readonly IConstraint _Constraint;
	private readonly bool _IsSuccess;

	public ConstraintResult(IConstraint constraint, bool isSuccess)
	{
		_Constraint = constraint;
		_IsSuccess = isSuccess;
	}
	public bool IsSuccess()
	{
		return _IsSuccess;
	}

	public string CreateMessage(string? actualExpression, TActual? actual)
	{
		return $"Expected {actualExpression} {_Constraint.ExpectationText}, but found {actual}.";
	}
}
