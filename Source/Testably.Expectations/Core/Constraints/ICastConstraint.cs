namespace Testably.Expectations.Core.Constraints;

/// <summary>
///     A complex constraint accessing <typeparamref name="TProperty" /> from type <typeparamref name="TValue" />.
/// </summary>
public interface ICastConstraint<in TValue, in TProperty> : IValueConstraint<TProperty>;
