using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Nodes;

internal class OrNode : CombinationNode
{
	public override Node Left { get; }
	public override Node Right { get; set; }
	private readonly string _textSeparator;

	public OrNode(Node left, Node right, string textSeparator = " or ")
	{
		_textSeparator = textSeparator;
		Left = left;
		Right = right;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		SourceValue<TValue> value,
		IEvaluationContext context)
		where TValue : default
	{
		ConstraintResult leftResult = await Left.IsMetBy(value, context);
		if (leftResult.IgnoreFurtherProcessing)
		{
			return leftResult;
		}

		ConstraintResult rightResult = await Right.IsMetBy(value, context);

		string combinedExpectation =
			$"{leftResult.ExpectationText}{_textSeparator}{rightResult.ExpectationText}";

		if (leftResult is ConstraintResult.Failure leftFailure &&
		    rightResult is ConstraintResult.Failure rightFailure)
		{
			return leftFailure.CombineWith(
				combinedExpectation,
				CombineResultTexts(leftFailure.ResultText, rightFailure.ResultText));
		}

		if (leftResult is ConstraintResult.Failure)
		{
			return rightResult.CombineWith(combinedExpectation, "");
		}

		return leftResult.CombineWith(combinedExpectation, "");
	}

	/// <inheritdoc />
	public override void SetReason(BecauseReason reason)
	{
		Right.SetReason(reason);
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"({Left} OR {Right})";

	private static string CombineResultTexts(string leftResultText, string rightResultText)
	{
		if (leftResultText == rightResultText)
		{
			return leftResultText;
		}

		return $"{leftResultText} and {rightResultText}";
	}
}
