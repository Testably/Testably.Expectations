using System;

namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A delegate expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface IDelegateConstraint<in TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value or the <paramref name="exception"/> meet the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue? actual, Exception? exception);
}

/// <summary>
///     A delegate expectation.
/// </summary>
public interface IDelegateConstraint : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="exception" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(Exception? exception);
}
