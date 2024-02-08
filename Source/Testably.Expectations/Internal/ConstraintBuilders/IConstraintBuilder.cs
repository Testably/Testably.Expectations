using Testably.Expectations.Core;
using Testably.Expectations.Core.Internal;

namespace Testably.Expectations.Internal.ConstraintBuilders;

internal interface IConstraintBuilder
{
	IConstraintBuilder Add(IConstraint constraint);
	ExpectationResult ApplyTo<TExpectation>(TExpectation actual);
}
