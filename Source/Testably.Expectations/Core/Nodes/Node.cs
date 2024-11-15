using System;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	public abstract void AddConstraint(IConstraint constraint);

	public abstract void AddMapping<TValue, TTarget>(
		IValueConstraint<TValue>? precondition,
		PropertyAccessor<TValue, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null);

	public abstract void AddNode(Node node, string? separator = null);

	public abstract Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken);

	public abstract void SetReason(BecauseReason becauseReason);
}
