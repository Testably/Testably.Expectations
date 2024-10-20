using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringExtensions
{
	private readonly struct IsConstraint(StringMatcher expected) : IExpectation<string?>
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (expected.Matches(actual))
			{
				return new ConstraintResult.Success<string?>(actual, ToString());
			}

			return new ConstraintResult.Failure<string?>(actual, ToString(),
				expected.GetExtendedFailure(actual));
		}

		/// <inheritdoc />
		public override string ToString()
			=> expected.GetExpectation(GrammaticVoice.ActiveVoice);
	}
}
