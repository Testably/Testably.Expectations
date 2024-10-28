namespace Testably.Expectations.Core;

/// <summary>
///     Base class for expectations, containing an <paramref name="expectationBuilder" />.
/// </summary>
internal class That<T>(IExpectationBuilder expectationBuilder) : IThat<T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	public IExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;
}
