using System;
using System.ComponentModel;

namespace Testably.Expectations.Core;

/// <summary>
///     Starting point for an expectation.
/// </summary>
public interface IExpectSubject<out T>
{
	/// <inheritdoc cref="object.Equals(object?)" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	bool Equals(object? obj);

	/// <inheritdoc cref="object.GetHashCode()" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	int GetHashCode();

	/// <inheritdoc cref="object.GetType()" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	Type GetType();

	/// <summary>
	///     Applies the <paramref name="builderOptions" /> to the <see cref="ExpectationBuilder" />.
	/// </summary>
	IThat<T> Should(Action<ExpectationBuilder> builderOptions);

	/// <inheritdoc cref="object.ToString()" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	string? ToString();
}
