namespace Testably.Expectations.Core.Nodes;

internal class AndNode : Node
{
	public Node Left { get; }
	public Node Right { get; set; }

	public AndNode(Node left, Node right)
	{
		Left = left;
		Right = right;
	}

	/// <inheritdoc />
	public override ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = Left.ApplyTo(actual);
		ExpectationResult rightResult = Right.ApplyTo(actual);

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
