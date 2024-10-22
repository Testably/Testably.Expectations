using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringExtensions
{
	private readonly struct DoesNotEndWithConstraint(
		string expected,
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

			if (expected.Length <= actual.Length &&
			    options.Comparer.Equals(
				    actual.Substring(actual.Length - expected.Length, expected.Length), expected))
			{
				return new ConstraintResult.Failure<string?>(actual, ToString(),
					$"found {Formatter.Format(actual)}");
			}

			return new ConstraintResult.Success<string?>(actual, ToString());
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"does not end with {Formatter.Format(expected)}{options}";
		}
	}
}
