using System;

namespace Testably.Expectations.Core.Nodes;

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
	public override ExpectationResult IsMetBy<TExpectation>(SourceValue<TExpectation> value)
		where TExpectation : default
	{
		ExpectationResult leftResult = Left.IsMetBy(value);
		ExpectationResult rightResult = Right.IsMetBy(value);

		string combinedExpectation =
			$"{leftResult.ExpectationText} or {rightResult.ExpectationText}";

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return leftFailure.CombineWith(
				combinedExpectation,
				CombineResultTexts(leftFailure.ResultText, rightFailure.ResultText));
		}

		return leftResult.CombineWith(combinedExpectation, "");
	}

	private static string CombineResultTexts(string leftResultText, string rightResultText)
	{
		if (leftResultText == rightResultText)
		{
			return leftResultText;
		}

		return $"{leftResultText} and {rightResultText}";
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"({Left} OR {Right})";
}
