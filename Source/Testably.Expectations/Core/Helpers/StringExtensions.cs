using System.Linq;

namespace Testably.Expectations.Core.Helpers;

internal static class StringExtensions
{
	public static string ToSingleLine(this string value)
	{
		return value.Replace("\n", "\\n").Replace("\r", "\\r");
	}
	public static string ToSingleLineIf(this string value, bool condition)
	{
		if (!condition)
		{
			return value;
		}
		return value.Replace("\n", "\\n").Replace("\r", "\\r");
	}

	public static string TruncateWithEllipsis(this string value, int maxLength)
	{
		if (value.Length <= maxLength)
		{
			return value;
		}

		const char ellipsis = '\u2026';
		return $"{value.Substring(0, maxLength)}{ellipsis}";
	}

	public static string PrependAOrAn(this string value)
	{
		char[] vocals = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
		if (value.Length > 0 && vocals.Contains(value[0]))
		{
			return $"an {value}";
		}

		return $"a {value}";
	}
}
