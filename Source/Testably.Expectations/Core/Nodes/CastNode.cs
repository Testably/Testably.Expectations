﻿using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Nodes;

internal class CastNode<T1, T2> : ManipulationNode
{
	public IConstraint<T1, T2> Constraint { get; }
	public override Node Inner { get; set; }

	public CastNode(IConstraint<T1, T2> constraint, Node inner)
	{
		Constraint = constraint;
		Inner = inner;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		ConstraintResult? result = await TryMeet(Constraint, value);
		if (!result.IgnoreFurtherProcessing && Inner != None && result is ConstraintResult.Success<T2> success)
		{
			return await Inner.IsMetBy(new SourceValue<T2>(success.Value, value.Exception));
		}

		return result;
	}

	/// <inheritdoc />
	public override string ToString()
		=> Constraint.ToString() ?? "<EMPTY EXPECTATION>";
}
