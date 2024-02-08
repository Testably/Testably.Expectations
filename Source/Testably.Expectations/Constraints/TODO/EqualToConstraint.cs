namespace Testably.Expectations.Constraints;

internal class EqualToConstraint<T> : SimpleConstraint<T>
{
	public override string ExpectationText => $"to be equal to {_expected}";
	private readonly T _expected;

	public EqualToConstraint(T expected)
	{
		_expected = expected;
	}

	protected override bool Satisfies(T? actual)
		=> _expected?.Equals(actual) == true;
}
