﻿namespace Testably.Expectations.Core.Nodes;

internal class OrNode : Node
{
	public Node Left { get; }
	public Node Right { get; set; }

	public OrNode(Node left, Node right)
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