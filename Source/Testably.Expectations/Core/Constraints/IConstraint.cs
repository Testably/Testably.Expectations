using System;
using Testably.Expectations.Core.Nodes;

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
public interface IConstraint<in TValue, TProperty> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value and the <paramref name="exception" /> meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue? actual, Exception? exception);
}
