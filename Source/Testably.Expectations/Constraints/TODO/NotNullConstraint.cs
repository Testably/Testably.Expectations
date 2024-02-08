using System.Data;
using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class NotNullConstraint<TActual> : IConstraint<TActual>
{
	public string ExpectationText => "not to be null";

	public ConstraintResult Satisfies(TActual? actual)
		=> new ConstraintResult<TActual?>(actual != null, actual);
}
