namespace Testably.Expectations.Common;

public interface IConstraintBuilder<TActual>
{
	ExpectationResult<TActual> ApplyTo(TActual actual);

	TConstraint Append<TConstraint>(TConstraint constraint) where TConstraint : IConstraint;
}
