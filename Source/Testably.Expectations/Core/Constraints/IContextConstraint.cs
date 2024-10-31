﻿using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A constraint on type <typeparamref name="TValue" /> that uses the <see cref="IEvaluationContext" />.
/// </summary>
public interface IContextConstraint<in TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation using the <see cref="IEvaluationContext" />.
	/// </summary>
	public ConstraintResult IsMetBy(TValue actual, IEvaluationContext context);
}
