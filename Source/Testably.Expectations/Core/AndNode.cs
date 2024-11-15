using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

internal class AndNode : Node2
{
	private const string DefaultSeparator = " and ";
	private List<(string, Node2)> _nodes = new();
	private string? _currentSeparator;
	private Node2 Current { get; set; }

	public AndNode(Node2 node)
	{
		Current = node;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken) where TValue : default
	{
		_nodes.Add((_currentSeparator ?? DefaultSeparator, Current));
		ConstraintResult? combinedResult = null;
		foreach ((string separator, Node2 node) in _nodes)
		{
			if (node is ExpectationNode expectationNode && expectationNode.IsEmpty())
			{
				continue;
			}
			var result = await node.IsMetBy(value, context, cancellationToken);
			combinedResult = CombineResults(combinedResult, result, separator);
			if (result.IgnoreFurtherProcessing)
			{
				return combinedResult;
			}
		}

		return combinedResult!;
	}

	private ConstraintResult CombineResults(ConstraintResult? combinedResult, ConstraintResult result, string separator)
	{
		if (combinedResult == null)
		{
			return result;
		}
		string combinedExpectation =
			$"{combinedResult.ExpectationText}{separator}{result.ExpectationText}";

		if (combinedResult is ConstraintResult.Failure leftFailure &&
		    result is ConstraintResult.Failure rightFailure)
		{
			return leftFailure.CombineWith(
				combinedExpectation,
				CombineResultTexts(leftFailure.ResultText, rightFailure.ResultText));
		}

		if (combinedResult is ConstraintResult.Failure onlyLeftFailure)
		{
			return onlyLeftFailure.CombineWith(
				combinedExpectation,
				onlyLeftFailure.ResultText);
		}

		if (result is ConstraintResult.Failure onlyRightFailure)
		{
			return onlyRightFailure.CombineWith(
				combinedExpectation,
				onlyRightFailure.ResultText);
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

	/// <inheritdoc />
	public override void AddConstraint(IConstraint constraint)
		=> Current.AddConstraint(constraint);

	/// <inheritdoc />
	public override void AddMapping<TValue, TTarget>(
		IValueConstraint<TValue>? precondition,
		PropertyAccessor<TValue, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null)
		where TTarget : default
		=> Current.AddMapping(precondition, propertyAccessor, expectationTextGenerator);

	/// <inheritdoc />
	public override void SetReason(BecauseReason becauseReason)
		=> Current.SetReason(becauseReason);

	public override void AddNode(Node2 node, string? separator = null)
	{
		_nodes.Add((_currentSeparator ?? DefaultSeparator, Current));
		Current = node;
		_currentSeparator = separator;
	}

	/// <inheritdoc />
	public override string ToString()
		=> string.Join(" and ", _nodes) + " and " + Current;
}
