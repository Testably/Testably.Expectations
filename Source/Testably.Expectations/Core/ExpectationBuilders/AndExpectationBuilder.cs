namespace Testably.Expectations.Core.ExpectationBuilders;

internal class AndExpectationBuilder : IExpectationBuilder
{
	private readonly IExpectationBuilder _left;
	private readonly IExpectationBuilder _right = new SimpleExpectationBuilder();

	public AndExpectationBuilder(IExpectationBuilder left)
	{
		_left = left;
	}

	#region IExpectationBuilder Members

	/// <inheritdoc />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		_right.Add(expectation);
		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = _left.ApplyTo(actual);
		if (leftResult is ExpectationResult.Success)
		{
			ExpectationResult rightResult = _right.ApplyTo(actual);
			if (rightResult is ExpectationResult.Success)
			{
				return new ExpectationResult.Success();
			}

			return rightResult;
		}

		return leftResult;
	}

	#endregion

	public override string ToString()
		=> $"{_left} AND {_right}";
}
