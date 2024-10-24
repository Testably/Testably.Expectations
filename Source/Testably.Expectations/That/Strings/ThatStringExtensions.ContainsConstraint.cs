﻿using System;
using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringExtensions
{
	private readonly struct ContainsConstraint(
		string expected,
		Quantifier quantifier,
		StringOptions options)
		: IConstraint<string?>
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (actual is null)
			{
				return new ConstraintResult.Failure<string?>(actual, ToString(),
					"found <null>");
			}

			int actualCount = CountOccurrences(actual, expected, options.Comparer);
			if (quantifier.Check(actualCount))
			{
				return new ConstraintResult.Success<string?>(actual, ToString());
			}

			return new ConstraintResult.Failure<string?>(actual, ToString(),
				$"found it {actualCount} times in {Formatter.Format(actual)}");
		}

		private static int CountOccurrences(string actual, string expected,
			IEqualityComparer<string> comparer)
		{
			if (expected.Length > actual.Length)
			{
				return 0;
			}

			int count = 0;
			int index = 0;
			while (index < actual.Length)
			{
				if (comparer.Equals(
					actual.Substring(index, Math.Min(expected.Length, actual.Length - index)),
					expected))
				{
					count++;
					index += expected.Length;
				}
				else
				{
					index++;
				}
			}

			return count;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			string quantifierString = quantifier.ToString();
			if (quantifierString == "never")
			{
				return $"does not contain {Formatter.Format(expected)}{options}";
			}

			return $"contains {Formatter.Format(expected)} {quantifier}{options}";
		}
	}
}
