using System;
using Testably.Expectations.TestFrameworks;

namespace Testably.Expectations.Common;
internal class Constraint<TActual> : IConstraint<TActual>
{
	public ConstraintResult<TActual> ApplyTo(TActual actual) => throw new System.NotImplementedException();
	public string ExpectationText => throw new System.NotImplementedException();
}
