using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class OfTypeConstraint<TType> : ComplexConstraint<TType, TType?>
{
	public override string ExpectationText => $"to be of type {typeof(TType).Name}";

	protected override ConstraintResult<TType?> Satisfies(TType? actual)
	{
		return new ConstraintResult<TType?>(actual is TType, actual);
	}
}
