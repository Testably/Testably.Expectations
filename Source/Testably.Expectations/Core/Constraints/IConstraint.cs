namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     An expectation.
/// </summary>
/// <remarks>This is a marker interface.</remarks>
public interface IConstraint
{
}

/// <summary>
///     A simple expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface IConstraint<in TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue actual);
}

/// <summary>
///     A complex expectation from type <typeparamref name="TValue" /> to type <typeparamref name="TProperty" />.
/// </summary>
// TODO VAB: Remove or move to DelegateConstraint
public interface IConstraint<in TValue, TProperty> : IDelegateConstraint<TValue>;
