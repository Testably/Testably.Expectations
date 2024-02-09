namespace Testably.Expectations.Core.ExpectationBuilders;

internal class OrExpectationBuilder : IExpectationBuilder
{
	private readonly IExpectationBuilder _left;
	private readonly IExpectationBuilder _right = new SimpleExpectationBuilder();

	internal OrExpectationBuilder(IExpectationBuilder left)
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
				$"{leftFailure.ExpectationText} or {rightFailure.ExpectationText}",
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		return new ExpectationResult.Success();
	}

	#endregion
}
