namespace Testably.Expectations.Core.ExpectationBuilders;

internal class OrExpectationBuilder(IExpectationBuilder left) : IExpectationBuilder
{
	private readonly IExpectationBuilder _right = new SimpleExpectationBuilder();

	#region IExpectationBuilder Members

	/// <inheritdoc />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		_right.Add(expectation);
		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = left.ApplyTo(actual);
		if (leftResult is not ExpectationResult.Success)
		{
			ExpectationResult rightResult = _right.ApplyTo(actual);
			if (rightResult is not ExpectationResult.Success)
			{
				// TODO: Check Expectation Text
				return new ExpectationResult.Failure(ToString(), "TODO");
			}
		}

		return new ExpectationResult.Success();
	}

	#endregion

	public override string ToString()
		=> $"{left} OR {_right}";
}
