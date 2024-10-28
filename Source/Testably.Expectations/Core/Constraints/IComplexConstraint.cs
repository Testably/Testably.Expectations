using System;

namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A complex constraint on type <typeparamref name="TValue" />.
/// </summary>
public interface IComplexConstraint<in TValue> : IConstraint
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value or the <paramref name="exception" /> meet the expectation.
	/// </summary>
	public ConstraintResult IsMetBy(TValue? actual, Exception? exception);
}

/// <summary>
///     A complex constraint accessing <typeparamref name="TProperty"/> from type <typeparamref name="TValue" />.
/// </summary>
public interface ICastConstraint<in TValue, TProperty> : IComplexConstraint<TValue>;
