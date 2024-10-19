using System;
using System.Text.RegularExpressions;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

/// <summary>
///     Matches a <see langword="string" /> against a pattern.
/// </summary>
public class StringMatcher(string pattern)
{
	private static readonly IMatchType ExactMatch = new ExactMatchType();

	private static readonly IMatchType RegexMatch = new RegexMatchType();

	private static readonly IMatchType WildcardMatch = new WildcardMatchType();
	private bool _ignoreCase;
	private IMatchType Type = ExactMatch;

	/// <summary>
	///     Interprets the expected <see langword="string" /> as <see cref="Regex" /> pattern.
	/// </summary>
	public StringMatcher AsRegex()
	{
		Type = RegexMatch;
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> as wildcard pattern.<br />
	///     Supports * to match zero or more characters and ? to match exactly one character.
	/// </summary>
	public StringMatcher AsWildcard()
	{
		Type = WildcardMatch;
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringMatcher IgnoringCase(bool ignoreCase = true)
	{
		_ignoreCase = ignoreCase;
		return this;
	}

	/// <summary>
	///     Implicitly converts the <see langword="string" /> to an exact match pattern.
	/// </summary>
	public static implicit operator StringMatcher(string pattern) => new(pattern);

	/// <summary>
	///     Matches the <paramref name="value" /> against the given match pattern.
	/// </summary>
	/// <param name="value">The value to match against the given pattern.</param>
	internal bool Matches(string? value)
	{
		return Type.Matches(value, pattern, _ignoreCase);
	}

	private interface IMatchType
	{
		bool Matches(string? value, string pattern, bool ignoreCase);
	}

	private sealed class WildcardMatchType : IMatchType
	{
		#region IMatchType Members

		public bool Matches(string? value, string pattern, bool ignoreCase)
		{
			if (value == null)
			{
				return false;
			}

			RegexOptions options = RegexOptions.Multiline;
			if (ignoreCase)
			{
				options |= RegexOptions.IgnoreCase;
			}

			return Regex.IsMatch(value, WildcardToRegularExpression(pattern), options);
		}

		#endregion

		private static string WildcardToRegularExpression(string value)
		{
			string regex = Regex.Escape(value)
				.Replace("\\?", ".")
				.Replace("\\*", ".*");
			return $"^{regex}$";
		}
	}

	private sealed class ExactMatchType : IMatchType
	{
		#region IMatchType Members

		public bool Matches(string? value, string pattern, bool ignoreCase)
		{
			return value?.Equals(pattern,
				ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) == true;
		}

		#endregion
	}

	private sealed class RegexMatchType : IMatchType
	{
		#region IMatchType Members

		public bool Matches(string? value, string pattern, bool ignoreCase)
		{
			if (value == null)
			{
				return false;
			}

			RegexOptions options = RegexOptions.Multiline;
			if (ignoreCase)
			{
				options |= RegexOptions.IgnoreCase;
			}

			return Regex.IsMatch(value, pattern, options);
		}

		#endregion
	}

	internal string GetExtendedFailure(string? actual)
	{
		if (Type is ExactMatchType)
		{
			return $" which {new StringDifference(actual, pattern)}";
		}

		return "";
	}

	internal string GetExpectation(GrammaticVoice grammaticVoice)
		=> grammaticVoice switch
		{
			GrammaticVoice.ActiveVoice =>
				$"{(IsExact ? "is equal to" : "matches")} {Formatter.Format(pattern)}",
			GrammaticVoice.PassiveVoice =>
				$"{(IsExact ? "equal to" : "matching")} {Formatter.Format(pattern)}",
			_ => throw new NotSupportedException("Invalid Grammar type")
		};

	private bool IsExact => Type is ExactMatchType;
}
