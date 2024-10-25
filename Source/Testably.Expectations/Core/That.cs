namespace Testably.Expectations.Core;

/// <summary>
///     Base class for expectations, containing an <see cref="ExpectationBuilder" />.
/// </summary>
public interface That<out T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	IExpectationBuilder ExpectationBuilder { get; }
}
/// <summary>
///     Base class for expectations, containing an <paramref name="expectationBuilder" />.
/// </summary>
public class ThatImpl<T>(IExpectationBuilder expectationBuilder) : That<T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	public IExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;
}
