﻿using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Nodes;

internal class ExpectationNode : Node
{
	public IConstraint Constraint { get; }

	public ExpectationNode(IConstraint constraint)
	{
		Constraint = constraint;
	}

	/// <inheritdoc />
	public override Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value, IEvaluationContext context)
		where TValue : default
		=> TryMeet(Constraint, value, context, Reason);

	/// <inheritdoc />
	public override string ToString()
		=> Constraint?.ToString() ?? "<EMPTY EXPECTATION>";
}
