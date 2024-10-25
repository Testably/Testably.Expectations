using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject contains the <paramref name="expected" /> <see langword="string" />.
	/// </summary>
	public static StringCountExpectationResult<string?, IThat<string?>> Contain(
		this IThat<string?> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		Quantifier? quantifier = new Quantifier();
		StringOptions? options = new StringOptions();
		return new StringCountExpectationResult<string?, IThat<string?>>(
			source.ExpectationBuilder.Add(
				new ContainsConstraint(expected, quantifier, options),
				b => b.AppendMethod(nameof(Contain), doNotPopulateThisValue)),
			source,
			quantifier,
			options);
	}

	/// <summary>
	///     Verifies that the subject contains the <paramref name="unexpected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, IThat<string?>> NotContain(
		this IThat<string?> source,
		string unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
	{
		Quantifier? quantifier = new Quantifier();
		quantifier.Exactly(0);
		StringOptions? options = new StringOptions();
		return new StringExpectationResult<string?, IThat<string?>>(source.ExpectationBuilder.Add(
				new ContainsConstraint(unexpected, quantifier, options),
				b => b.AppendMethod(nameof(NotContain), doNotPopulateThisValue)),
			source,
			options);
	}

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
				return new ConstraintResult.Failure<string?>(null, ToString(),
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
				return $"not contain {Formatter.Format(expected)}{options}";
			}

			return $"contain {Formatter.Format(expected)} {quantifier}{options}";
		}
	}
}
