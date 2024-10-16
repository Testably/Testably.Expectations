namespace Testably.Expectations.Core.Helpers;
internal static class StringExtensions
{
	public static string ShowNewLines(this string value)
	{
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
}
