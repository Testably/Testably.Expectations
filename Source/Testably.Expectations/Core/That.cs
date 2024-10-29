namespace Testably.Expectations.Core;

/// <summary>
///     Base class for expectations, containing an <paramref name="expectationBuilder" />.
/// </summary>
internal class That<T>(ExpectationBuilder expectationBuilder) : IThat<T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	public ExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;
}
