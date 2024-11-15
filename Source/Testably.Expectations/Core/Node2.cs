using System;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

internal abstract class Node2
{
	public abstract Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken);

	public abstract void AddConstraint(IConstraint constraint);

	public abstract void AddMapping<TValue, TTarget>(
		IValueConstraint<TValue>? precondition,
		PropertyAccessor<TValue, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null);

	public abstract void SetReason(BecauseReason becauseReason);

	public abstract void AddNode(Node2 node, string? separator = null);
}
