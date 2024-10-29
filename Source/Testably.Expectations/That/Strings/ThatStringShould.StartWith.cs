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
	///     Verifies that the subject does not start with the <paramref name="unexpected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, IThat<string?>> NotStartWith(
		this IThat<string?> source,
		string unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
	{
		StringOptions? options = new();
		return new StringExpectationResult<string?, IThat<string?>>(
			source.ExpectationBuilder
				.AddConstraint(new DoesNotStartWithValueConstraint(unexpected, options))
				.AppendMethodStatement(nameof(NotStartWith), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject starts with the <paramref name="expected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, IThat<string?>> StartWith(
		this IThat<string?> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		StringOptions? options = new();
		return new StringExpectationResult<string?, IThat<string?>>(
			source.ExpectationBuilder
				.AddConstraint(new StartsWithValueConstraint(expected, options))
				.AppendMethodStatement(nameof(StartWith), doNotPopulateThisValue),
			source,
			options);
	}

	private readonly struct StartsWithValueConstraint(
		string expected,
		StringOptions options)
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

			if (expected.Length > actual.Length)
			{
				return new ConstraintResult.Failure<string?>(actual, ToString(),
					$"it had only length {actual.Length} which is shorter than the expected length of {expected.Length}");
			}

			if (options.Comparer.Equals(actual.Substring(0, expected.Length), expected))
			{
				return new ConstraintResult.Success<string?>(actual, ToString());
			}

			return new ConstraintResult.Failure<string?>(actual, ToString(),
				$"found {Formatter.Format(actual)}");
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"start with {Formatter.Format(expected)}{options}";
		}
	}

	private readonly struct DoesNotStartWithValueConstraint(
		string expected,
		StringOptions options)
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

			if (expected.Length <= actual.Length &&
			    options.Comparer.Equals(actual.Substring(0, expected.Length), expected))
			{
				return new ConstraintResult.Failure<string?>(actual, ToString(),
					$"found {Formatter.Format(actual)}");
			}

			return new ConstraintResult.Success<string?>(actual, ToString());
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"not start with {Formatter.Format(expected)}{options}";
		}
	}
}
