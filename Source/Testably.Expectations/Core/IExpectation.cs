using System;

namespace Testably.Expectations.Core;

/// <summary>
///     An expectation.
/// </summary>
/// <remarks>This is a marker interface.</remarks>
public interface IExpectation
{
}

/// <summary>
///     A simple expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface IExpectation<in TValue> : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue actual);
}

/// <summary>
///     A complex expectation from type <typeparamref name="TValue" /> to type <typeparamref name="TProperty" />.
/// </summary>
public interface IExpectation<in TValue, TProperty> : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value and the <paramref name="exception" /> meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue? actual, Exception? exception);
}
