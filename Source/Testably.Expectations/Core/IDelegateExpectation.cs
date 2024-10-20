using System;

namespace Testably.Expectations.Core;

/// <summary>
///     A delegate expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface IDelegateExpectation<TValue> : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="value" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(SourceValue<TValue> value);
}

/// <summary>
///     A delegate expectation.
/// </summary>
public interface IDelegateExpectation : IExpectation
{
	/// <summary>
	///     Checks if the <paramref name="exception" /> value meets the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(Exception? exception);
}
