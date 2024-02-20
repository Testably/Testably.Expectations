using System.Threading.Tasks;

namespace Testably.Expectations.Core;

/// <summary>
///     An expectation.
/// </summary>
/// <remarks>This is a marker interface.</remarks>
public interface IAsyncExpectation
{
}

/// <summary>
///     A simple expectation on type <typeparamref name="TExpectation" />.
/// </summary>
public interface IAsyncExpectation<in TExpectation> : IAsyncExpectation
{
	/// <summary>
	///     Checks if the <paramref name="actual" /> value meets the expectation.
	/// </summary>
	public Task<ExpectationResult> IsMetByAsync(TExpectation? actual);
}

/// <summary>
///     A complex expectation from type <typeparamref name="TExpectation" /> to type <typeparamref name="TProperty" />.
/// </summary>
public interface IAsyncExpectation<in TExpectation, TProperty> : IAsyncExpectation<TExpectation>
{
}
