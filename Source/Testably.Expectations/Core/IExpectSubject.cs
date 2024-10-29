namespace Testably.Expectations.Core;

/// <summary>
///     Starting point for an expectation.
/// </summary>
public interface IExpectSubject<out T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	ExpectationBuilder ExpectationBuilder { get; }
}
