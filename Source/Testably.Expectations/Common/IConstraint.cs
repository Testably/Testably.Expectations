namespace Testably.Expectations.Common;

public interface IConstraint
{
	string ExpectationText { get; }
}

public interface IConstraint<TActual> : IConstraint
	{
	ConstraintResult<TActual> ApplyTo(TActual actual);
}
public interface IConstraint<TActual, TTarget> : IConstraint
	{
	ConstraintResult<TTarget> ApplyTo(TActual actual);
}
