using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Nodes;

internal class ExpectationNode : Node
{
	public IConstraint Constraint { get; }

	public ExpectationNode(IConstraint constraint)
	{
		Constraint = constraint;
	}

	/// <inheritdoc />
	public override Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken)
		where TValue : default
		=> TryMeet(Constraint, value, Reason, context, cancellationToken);

	/// <inheritdoc />
	public override string ToString()
		=> Constraint?.ToString() ?? "<EMPTY EXPECTATION>";
}
