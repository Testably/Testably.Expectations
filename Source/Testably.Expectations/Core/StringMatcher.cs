using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

/// <summary>
///     Matches a <see langword="string" /> against a pattern.
/// </summary>
public class StringMatcher(string? pattern)
{
	private static readonly IMatchType ExactMatch = new ExactMatchType();
	private static readonly IMatchType RegexMatch = new RegexMatchType();
	private static readonly IMatchType WildcardMatch = new WildcardMatchType();

	private IEqualityComparer<string>? _comparer;
	private bool _ignoreCase;
	private IMatchType _type = ExactMatch;

	/// <summary>
	///     Interprets the expected <see langword="string" /> as <see cref="Regex" /> pattern.
	/// </summary>
	public StringMatcher AsRegex()
	{
		_type = RegexMatch;
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> as wildcard pattern.<br />
	///     Supports * to match zero or more characters and ? to match exactly one character.
	/// </summary>
	public StringMatcher AsWildcard()
	{
		_type = WildcardMatch;
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
	public static implicit operator StringMatcher(string? pattern) => new(pattern);

	/// <summary>
	///     Specifies a specific <see cref="IEqualityComparer{T}" /> to use for comparing <see langword="string" />s.
	/// </summary>
	/// <remarks>
	///     If set to <see langword="null" /> (default), uses the <see cref="StringComparer.Ordinal" /> or
	///     <see cref="StringComparer.OrdinalIgnoreCase" /> depending on whether the casing is ignored.
	/// </remarks>
	public StringMatcher UsingComparer(IEqualityComparer<string>? comparer)
	{
		_comparer = comparer;
		return this;
	}

	internal string GetExpectation(GrammaticVoice grammaticVoice)
		=> grammaticVoice switch
		{
			GrammaticVoice.ActiveVoice =>
				$"{(_type is ExactMatchType ? "is equal to" : "matches")} {Formatter.Format(pattern.ToSingleLine())}",
			GrammaticVoice.PassiveVoice =>
				$"{(_type is ExactMatchType ? "equal to" : "matching")} {Formatter.Format(pattern.ToSingleLine())}",
			_ => throw new NotSupportedException("Invalid Grammar type")
		};

	internal string GetExtendedFailure(string? actual)
		=> _type.GetExtendedFailure(actual, pattern, _ignoreCase,
			_comparer ?? UseDefaultComparer(_ignoreCase));

	/// <summary>
	///     Matches the <paramref name="value" /> against the given match pattern.
	/// </summary>
	/// <param name="value">The value to match against the given pattern.</param>
	internal bool Matches(string? value)
		=> _type.Matches(value, pattern, _ignoreCase, _comparer ?? UseDefaultComparer(_ignoreCase));

	private static StringComparer UseDefaultComparer(bool ignoreCase)
		=> ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;

	private interface IMatchType
	{
		string GetExtendedFailure(string? actual, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer);

		bool Matches(string? value, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer);
	}

	private sealed class WildcardMatchType : IMatchType
	{
		#region IMatchType Members

		/// <inheritdoc />
		public string GetExtendedFailure(string? actual, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer) => "";

		public bool Matches(string? value, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer)
		{
			if (value is null || pattern is null)
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
				.Replace("\\*", "(.|\\n)*");
			return $"^{regex}$";
		}
	}

	private sealed class ExactMatchType : IMatchType
	{
		#region IMatchType Members

		/// <inheritdoc />
		public string GetExtendedFailure(string? actual, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer)
		{
			if (actual == null || pattern == null)
			{
				return "";
			}

			int minCommonLength = Math.Min(actual.Length, pattern.Length);
			StringDifference stringDifference = new StringDifference(actual, pattern, comparer);
			if (stringDifference.IndexOfFirstMismatch == 0 &&
			    comparer.Equals(actual.TrimStart(), pattern))
			{
				return " which has unexpected whitespace at the beginning";
			}

			if (stringDifference.IndexOfFirstMismatch == 0 &&
			    comparer.Equals(actual, pattern.TrimStart()))
			{
				return " which misses some whitespace at the beginning";
			}

			if (stringDifference.IndexOfFirstMismatch == minCommonLength &&
			    comparer.Equals(actual.TrimEnd(), pattern))
			{
				return " which has unexpected whitespace at the end";
			}

			if (stringDifference.IndexOfFirstMismatch == minCommonLength &&
			    comparer.Equals(actual, pattern.TrimEnd()))
			{
				return " which misses some whitespace at the end";
			}

			if (stringDifference.IndexOfFirstMismatch == 0 ||
			    stringDifference.IndexOfFirstMismatch == minCommonLength)
			{
				if (comparer.Equals(actual.Trim(), pattern.Trim()))
				{
					return " which differs in whitespace";
				}

				if (actual.Length < pattern.Length)
				{
					return
						$" with a length of {actual.Length} which is shorter than the expected length of {pattern.Length}";
				}

				if (actual.Length > pattern.Length)
				{
					return
						$" with a length of {actual.Length} which is longer than the expected length of {pattern.Length}";
				}
			}

			return $" which {new StringDifference(actual, pattern, comparer)}";
		}

		public bool Matches(string? value, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer)
		{
			if (value is null && pattern is null)
			{
				return true;
			}

			if (value is null || pattern is null)
			{
				return false;
			}

			return comparer.Equals(value, pattern);
		}

		#endregion
	}

	private sealed class RegexMatchType : IMatchType
	{
		#region IMatchType Members

		/// <inheritdoc />
		public string GetExtendedFailure(string? actual, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer) => "";

		public bool Matches(string? value, string? pattern, bool ignoreCase,
			IEqualityComparer<string> comparer)
		{
			if (value is null || pattern is null)
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
}
