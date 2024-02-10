#if NETSTANDARD2_0
using System;
using System.Diagnostics.CodeAnalysis;

namespace Testably.Expectations.Polyfills;

/// <summary>
///     Provides extension methods to simplify writing platform independent tests.
/// </summary>
[ExcludeFromCodeCoverage]
internal static class StringExtensionMethods
{
	/// <summary>
	///     Reports the zero-based index of the first occurrence of the specified Unicode character in this string. A parameter
	///     specifies the type of search to use for the specified character.
	/// </summary>
	/// <returns>
	///     The zero-based index of <paramref name="value" /> if that character is found, or <c>-1</c> if it is not.
	/// </returns>
	internal static int IndexOf(
		this string @this,
		char value,
		StringComparison comparisonType)
	{
		return @this.IndexOf($"{value}", comparisonType);
	}
}
#endif
