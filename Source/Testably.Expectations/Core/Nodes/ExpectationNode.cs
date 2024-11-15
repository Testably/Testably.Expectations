using System;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Nodes;

internal class ExpectationNode : Node
{
	protected IConstraint? Constraint { get; private set; }

	protected Node? Inner { get; private set; }

	protected BecauseReason? Reason { get; private set; }

	private Func<ConstraintResult?, ConstraintResult, ConstraintResult>? _combineResults;

	/// <inheritdoc />
	public override void AddConstraint(IConstraint constraint)
	{
		if (Inner is not null)
		{
			Inner.AddConstraint(constraint);
		}
		else if (Constraint is null)
		{
			Constraint = constraint;
		}
		else
		{
			throw new InvalidOperationException(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
		}
	}

	/// <inheritdoc />
	public override void AddMapping<TValue, TTarget>(
		IValueConstraint<TValue>? precondition,
		PropertyAccessor<TValue, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null)
		where TTarget : default
	{
		MappingNode<TValue, TTarget> mappingNode =
			new(precondition, propertyAccessor,
				expectationTextGenerator);
		Inner = mappingNode;
		_combineResults = mappingNode.CombineResults;
	}

	/// <inheritdoc />
	public override void AddNode(Node node, string? separator = null)
		=> throw new NotSupportedException(
			$"Don't specify the inner node for Expectation nodes directly. You can use {nameof(AddMapping)} instead.");

	public bool IsEmpty()
	{
		return Constraint is null && Inner is null;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken) where TValue : default
	{
		ConstraintResult? result = null;
		if (Constraint is IValueConstraint<TValue?> valueConstraint)
		{
			result = valueConstraint.IsMetBy(value);
			result = Reason?.ApplyTo(result) ?? result;
		}
		else if (Constraint is IContextConstraint<TValue?> contextConstraint)
		{
			result = contextConstraint.IsMetBy(value, context);
			result = Reason?.ApplyTo(result) ?? result;
		}
		else if (Constraint is IAsyncConstraint<TValue?> asyncConstraint)
		{
			result = await asyncConstraint.IsMetBy(value, cancellationToken);
			result = Reason?.ApplyTo(result) ?? result;
		}
		else if (Constraint is IAsyncContextConstraint<TValue?> asyncContextConstraint)
		{
			result = await asyncContextConstraint.IsMetBy(value, context, cancellationToken);
			result = Reason?.ApplyTo(result) ?? result;
		}

		if (Inner != null)
		{
			ConstraintResult innerResult = await Inner.IsMetBy(value, context, cancellationToken);
			return _combineResults?.Invoke(result, innerResult) ?? innerResult;
		}

		if (_combineResults != null && result != null)
		{
			return _combineResults.Invoke(null, result);
		}

		return result ?? throw new InvalidOperationException(
			$"The expectation node does not support {typeof(TValue).Name} {value}");
	}

	/// <inheritdoc />
	public override void SetReason(BecauseReason becauseReason)
	{
		Reason = becauseReason;
	}

	/// <inheritdoc />
	public override string ToString()
		=> Constraint + (Inner == null ? "" : Inner.ToString());
}
