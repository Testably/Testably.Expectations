using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints;
internal class AndConstraint<TActual> : IConstraint<TActual>
{
	public AndConstraint(IConstraint<TActual> left)
	{

	}

	public ConstraintResult<TActual> ApplyTo(TActual actual) => throw new System.NotImplementedException();
	public string ExpectationText => throw new System.NotImplementedException();
}
