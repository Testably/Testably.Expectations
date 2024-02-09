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
	public ExpectationResult IsMetBy(TExpectation actual);
}

/// <summary>
///     A complex expectation from type <typeparamref name="TExpectation" /> to type <typeparamref name="TProperty" />.
/// </summary>
public interface IExpectation<in TExpectation, TProperty> : IExpectation<TExpectation>
{
}
