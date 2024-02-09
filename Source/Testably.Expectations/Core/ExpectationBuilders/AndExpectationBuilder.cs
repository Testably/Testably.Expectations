namespace Testably.Expectations.Core.ExpectationBuilders;

internal class AndExpectationBuilder : IExpectationBuilder
{
	private readonly IExpectationBuilder _left;
	private readonly IExpectationBuilder _right = new SimpleExpectationBuilder();

	internal AndExpectationBuilder(IExpectationBuilder left)
	{
		_left = left;
	}

	#region IExpectationBuilder Members

	/// <inheritdoc cref="IExpectationBuilder.Add(IExpectation)" />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		_right.Add(expectation);
		return this;
	}

	/// <inheritdoc cref="IExpectationBuilder.ApplyTo{TExpectation}(TExpectation)" />
	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = _left.ApplyTo(actual);
		ExpectationResult rightResult = _right.ApplyTo(actual);

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return new ExpectationResult.Failure(
				$"{leftFailure.ExpectationText} and {rightFailure.ExpectationText}",
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		if (leftResult is ExpectationResult.Success)
		{
			return rightResult;
		}
		return leftResult;
	}

	#endregion
}
