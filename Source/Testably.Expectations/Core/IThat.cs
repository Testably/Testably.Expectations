using System;
using System.ComponentModel;

namespace Testably.Expectations.Core;

/// <summary>
///     Base class for expectations, containing an <see cref="ExpectationBuilder" />.
/// </summary>
// ReSharper disable once UnusedTypeParameter
public interface IThat<out T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ExpectationBuilder ExpectationBuilder { get; }

	/// <inheritdoc cref="object.Equals(object?)" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	bool Equals(object? obj);

	/// <inheritdoc cref="object.GetHashCode()" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	int GetHashCode();

	/// <inheritdoc cref="object.GetType()" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	Type GetType();

	/// <inheritdoc cref="object.ToString()" />
	[EditorBrowsable(EditorBrowsableState.Never)]
	string? ToString();
}
