using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static StringEqualityResult<string?, IThat<string?>> BeOneOf(
		this IThat<string?> source,
		params string?[] expected)
	{
		StringEqualityOptions options = new();
		return new StringEqualityResult<string?, IThat<string?>>(
			source.ExpectationBuilder
				.AddConstraint(new BeOneOfConstraint(expected, options)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static StringEqualityResult<string?, IThat<string?>> NotBeOneOf(
		this IThat<string?> source,
		params string?[] unexpected)
	{
		StringEqualityOptions options = new();
		return new StringEqualityResult<string?, IThat<string?>>(
			source.ExpectationBuilder
				.AddConstraint(new NotBeOneOfConstraint(unexpected, options)),
			source,
			options);
	}

	private readonly struct BeOneOfConstraint(
		string?[] expectedValues,
		StringEqualityOptions options)
		: IValueConstraint<string?>
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (actual is null)
			{
				return new ConstraintResult.Failure<string?>(null, ToString(),
					"found <null>");
			}

			foreach (string? expectedValue in expectedValues)
			{
				if (options.Comparer.Equals(actual, expectedValue))
				{
					return new ConstraintResult.Success<string?>(actual, ToString());
				}
			}

			return new ConstraintResult.Failure<string?>(actual, ToString(),
				$"found {Formatter.Format(actual)}");
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"be one of {Formatter.Format(expectedValues)}{options}";
		}
	}

	private readonly struct NotBeOneOfConstraint(
		string?[] unexpectedValues,
		StringEqualityOptions options)
		: IValueConstraint<string?>
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (actual is null)
			{
				return new ConstraintResult.Failure<string?>(null, ToString(),
					"found <null>");
			}

			foreach (string? unexpectedValue in unexpectedValues)
			{
				if (options.Comparer.Equals(actual, unexpectedValue))
				{
					return new ConstraintResult.Failure<string?>(actual, ToString(),
						$"found {Formatter.Format(actual)}");
				}
			}

			return new ConstraintResult.Success<string?>(actual, ToString());
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"not be one of {Formatter.Format(unexpectedValues)}{options}";
		}
	}
}
