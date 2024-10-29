using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A simple expectation on type <typeparamref name="TValue" /> that uses the <see cref="IEvaluationContext"/>.
/// </summary>
public interface IContextConstraint<in TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue actual, IEvaluationContext context);
}
