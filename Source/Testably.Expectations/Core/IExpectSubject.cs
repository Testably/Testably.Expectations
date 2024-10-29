using System;

namespace Testably.Expectations.Core;

/// <summary>
///     Starting point for an expectation.
/// </summary>
public interface IExpectSubject<out T>
{
	/// <summary>
	///     Applies the <paramref name="builderOptions" /> to the <see cref="ExpectationBuilder" />.
	/// </summary>
	IThat<T> Should(Action<ExpectationBuilder> builderOptions);
}
