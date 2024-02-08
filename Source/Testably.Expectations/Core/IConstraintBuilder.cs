namespace Testably.Expectations.Core;

public interface IConstraintBuilder<TActual>
{
	TConstraint Append<TConstraint>(TConstraint constraint) where TConstraint : IConstraint;
	ExpectationResult<TActual> ApplyTo(TActual actual);
}
