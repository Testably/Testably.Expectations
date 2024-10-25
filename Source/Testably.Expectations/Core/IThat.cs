namespace Testably.Expectations.Core;

/// <summary>
///     Base class for expectations, containing an <see cref="ExpectationBuilder" />.
/// </summary>
public interface IThat<out T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	IExpectationBuilder ExpectationBuilder { get; }
}
