﻿namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A simple expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface IValueConstraint<in TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue actual);
}
