using System.Diagnostics;

namespace Testably.Expectations.Core.Nodes;

[StackTraceHidden]
internal class AndNode : CombinationNode
{
	public override Node Left { get; }
	public override Node Right { get; set; }
	private readonly string _textSeparator;

	public AndNode(Node left, Node right, string textSeparator = " and ")
	{
		Left = left;
		Right = right;
		_textSeparator = textSeparator;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		ExpectationResult leftResult = Left.IsMetBy(value);
		ExpectationResult rightResult = Right.IsMetBy(value);

		string combinedExpectation =
			$"{leftResult.ExpectationText}{_textSeparator}{rightResult.ExpectationText}";

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return leftFailure.CombineWith(
				combinedExpectation,
				CombineResultTexts(leftFailure.ResultText, rightFailure.ResultText));
		}

		if (leftResult is ExpectationResult.Failure onlyLeftFailure)
		{
			return onlyLeftFailure.CombineWith(
				combinedExpectation,
				onlyLeftFailure.ResultText);
		}

		if (rightResult is ExpectationResult.Failure onlyRightFailure)
		{
			return onlyRightFailure.CombineWith(
				combinedExpectation,
				onlyRightFailure.ResultText);
		}

		return leftResult.CombineWith(combinedExpectation, "");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"({Left} AND {Right})";

	private static string CombineResultTexts(string leftResultText, string rightResultText)
	{
		if (leftResultText == rightResultText)
		{
			return leftResultText;
		}

		return $"{leftResultText} and {rightResultText}";
	}
}
