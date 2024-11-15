using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Nodes;

internal class OrNode : Node
{
	internal Node Current { get; set; }
	private readonly List<Node> _nodes = new();

	public OrNode(Node node)
	{
		Current = node;
	}

	/// <inheritdoc />
	public override void AddConstraint(IConstraint constraint)
		=> Current.AddConstraint(constraint);

	/// <inheritdoc />
	public override Node? AddMapping<TValue, TTarget>(
		PropertyAccessor<TValue, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null)
		where TTarget : default
		=> Current.AddMapping(propertyAccessor, expectationTextGenerator);

	public override void AddNode(Node node, string? separator = null)
	{
		_nodes.Add(Current);
		Current = node;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken) where TValue : default
	{
		_nodes.Add(Current);
		ConstraintResult? combinedResult = null;
		foreach (Node node in _nodes)
		{
			ConstraintResult result = await node.IsMetBy(value, context, cancellationToken);
			combinedResult = CombineResults(combinedResult, result);
			if (result.IgnoreFurtherProcessing)
			{
				return combinedResult;
			}
		}

		return combinedResult!;
	}

	/// <inheritdoc />
	public override void SetReason(BecauseReason becauseReason)
		=> Current.SetReason(becauseReason);

	/// <inheritdoc />
	public override string ToString()
		=> string.Join(" or ", _nodes) + " or " + Current;

	private ConstraintResult CombineResults(ConstraintResult? combinedResult,
		ConstraintResult result)
	{
		const string _textSeparator = " or ";
		if (combinedResult == null)
		{
			return result;
		}

		string combinedExpectation =
			$"{combinedResult.ExpectationText}{_textSeparator}{result.ExpectationText}";

		if (combinedResult is ConstraintResult.Failure leftFailure &&
		    result is ConstraintResult.Failure rightFailure)
		{
			return leftFailure.CombineWith(
				combinedExpectation,
				CombineResultTexts(leftFailure.ResultText, rightFailure.ResultText));
		}

		if (combinedResult is ConstraintResult.Failure)
		{
			return result.CombineWith(combinedExpectation, "");
		}

		return combinedResult.CombineWith(combinedExpectation, "");
	}

	private static string CombineResultTexts(string leftResultText, string rightResultText)
	{
		if (leftResultText == rightResultText)
		{
			return leftResultText;
		}

		return $"{leftResultText} and {rightResultText}";
	}
}
