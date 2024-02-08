using Testably.Expectations.Core;

namespace Testably.Expectations.Internal.ConstraintBuilders;

internal interface IConstraintBuilder
{
	IConstraintBuilder Add(IConstraint constraint);
	ExpectationResult ApplyTo<TExpectation>(TExpectation actual);
}
