﻿namespace Testably.Expectations.Core.Nodes;

internal class OrNode : CombinationNode
{
	public override Node Left { get; }
	public override Node Right { get; set; }

	public OrNode(Node left, Node right)
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
			$"{leftResult.ExpectationText} or {rightResult.ExpectationText}";

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return new ExpectationResult.Failure(
				combinedExpectation,
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		return new ExpectationResult.Success(combinedExpectation);
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"({Left} OR {Right})";
}
