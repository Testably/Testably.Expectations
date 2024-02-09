namespace Testably.Expectations.Core;

/// <summary>
///     A simple nullable expectation on type <typeparamref name="TExpectation" />.
/// </summary>
public interface INullableExpectation<in TExpectation> : IExpectation<TExpectation>
{
}

/// <summary>
///     A nullable expectation.
/// </summary>
/// <remarks>This is a marker interface.</remarks>
public interface INullableExpectation : IExpectation
{
}
