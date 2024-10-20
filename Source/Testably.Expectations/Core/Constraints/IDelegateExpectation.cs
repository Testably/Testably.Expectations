using System;

namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A delegate expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface IDelegateConstraint<TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="value" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(SourceValue<TValue> value);
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
