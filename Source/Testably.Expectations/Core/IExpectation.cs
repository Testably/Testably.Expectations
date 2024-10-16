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
///     A simple expectation on type <typeparamref name="TExpectation" />.
/// </summary>
public interface IExpectation<in TExpectation> : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ExpectationResult IsMetBy(TExpectation actual);
}

/// <summary>
///     A delegate expectation on type <typeparamref name="TExpectation" />.
/// </summary>
public interface IDelegateExpectation<in TExpectation> : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ExpectationResult IsMetBy(TExpectation? actual, Exception? exception);
}

/// <summary>
///     A delegate expectation on type <typeparamref name="TExpectation" />.
/// </summary>
public interface IDelegateExpectation : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public ExpectationResult IsMetBy(Exception? exception);
}

/// <summary>
///     A complex expectation from type <typeparamref name="TExpectation" /> to type <typeparamref name="TProperty" />.
/// </summary>
public interface IExpectation<in TExpectation, TProperty> : IExpectation<TExpectation>
{
}
