using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal class CastNode<T1, T2> : ManipulationNode
{
	public ICastConstraint<T1, T2> CastConstraint { get; }
	public override Node Inner { get; set; }

	public CastNode(ICastConstraint<T1, T2> castConstraint, Node inner)
	{
		CastConstraint = castConstraint;
		Inner = inner;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		SourceValue<TValue> value,
		IEvaluationContext context)
		where TValue : default
	{
		ConstraintResult? result = await TryMeet(CastConstraint, value, context, Reason);
		if (!result.IgnoreFurtherProcessing && Inner != None && result is ConstraintResult.Success<T2> success)
		{
			return (await Inner.IsMetBy(new SourceValue<T2>(success.Value, value.Exception), context))
				.UpdateExpectationText(e => $"{result.ExpectationText} {e.ExpectationText}");
		}

		return result;
	}


	/// <inheritdoc />
	public override string ToString()
		=> CastConstraint.ToString() ?? "<EMPTY EXPECTATION>";
}
