using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class OfTypeConstraint<TType> : IConstraint<TType, TType?>
{
	public string ExpectationText => $"to be of type {typeof(TType).Name}";

	public ConstraintResult Satisfies(TType? actual)
	{
		return new ConstraintResult<TType?>(actual is TType, actual);
	}
}
