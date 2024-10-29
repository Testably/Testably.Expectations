using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	public static Node None { get; } = new NoneNode();
	protected BecauseReason? Reason { get; private set; }

	public abstract Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context);

	public virtual void SetReason(BecauseReason reason)
	{
		Reason = reason;
	}

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";

	protected static async Task<ConstraintResult> TryMeet<TValue>(IConstraint constraint,
		TValue? value,
		IEvaluationContext context,
		BecauseReason? reason)
	{
		if (constraint is IValueConstraint<TValue?> valueConstraint)
		{
			ConstraintResult result = valueConstraint.IsMetBy(value);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (constraint is IContextConstraint<TValue?> contextConstraint)
		{
			ConstraintResult result = contextConstraint.IsMetBy(value, context);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (constraint is IAsyncConstraint<TValue?> asyncConstraint)
		{
			ConstraintResult result = await asyncConstraint.IsMetBy(value);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (value is DelegateValue delegateValue)
		{
			return await TryMeet(constraint, delegateValue.Exception, context, reason);
		}

		throw new InvalidOperationException(
			$"The expectation node does not support {typeof(TValue).Name} {value}");
	}

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override Task<ConstraintResult> IsMetBy<TValue>(TValue? value,
			IEvaluationContext context)
			where TValue : default
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}
}
