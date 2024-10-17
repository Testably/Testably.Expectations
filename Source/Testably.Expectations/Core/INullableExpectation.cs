namespace Testably.Expectations.Core;

/// <summary>
///     A simple nullable expectation on type <typeparamref name="TValue" />.
/// </summary>
public interface INullableExpectation<in TValue> : IExpectation<TValue>
{
}

/// <summary>
///     A nullable expectation.
/// </summary>
/// <remarks>This is a marker interface.</remarks>
public interface INullableExpectation : IExpectation
{
}
