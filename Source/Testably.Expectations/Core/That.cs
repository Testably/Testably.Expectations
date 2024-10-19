namespace Testably.Expectations.Core;

/// <summary>
///     Base class for expectations, containing an <paramref name="expectationBuilder" />.
/// </summary>
public class That<T>(IExpectationBuilder expectationBuilder)
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	public IExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;
}
