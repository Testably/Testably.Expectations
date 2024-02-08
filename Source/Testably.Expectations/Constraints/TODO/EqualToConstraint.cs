using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class EqualToConstraint<T> : IConstraint<T>
{
	public string ExpectationText => $"to be equal to {_expected}";
	private readonly T _expected;

	public EqualToConstraint(T expected)
	{
		_expected = expected;
	}

	ConstraintResult IConstraint<T>.Satisfies(T? actual)
		=> new ConstraintResult<T?>(_expected?.Equals(actual) == true, actual);
}
