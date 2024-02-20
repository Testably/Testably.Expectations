namespace Testably.Expectations.Core.Nodes;

internal class AndNode : CombinationNode
{
	public override Node Left { get; }
	public override Node Right { get; set; }

	public AndNode(Node left, Node right)
	{
		Left = left;
		Right = right;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = Left.IsMetBy(actual);
		ExpectationResult rightResult = Right.IsMetBy(actual);

		string combinedExpectation =
			$"{leftResult.ExpectationText} and {rightResult.ExpectationText}";

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return new ExpectationResult.Failure(
				combinedExpectation,
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		if (leftResult is ExpectationResult.Failure onlyLeftFailure)
		{
			return new ExpectationResult.Failure(
				combinedExpectation,
				onlyLeftFailure.ResultText);
		}

		if (rightResult is ExpectationResult.Failure onlyRightFailure)
		{
			return new ExpectationResult.Failure(
				combinedExpectation,
				onlyRightFailure.ResultText);
		}

		return new ExpectationResult.Success(combinedExpectation);
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"({Left} AND {Right})";
}
