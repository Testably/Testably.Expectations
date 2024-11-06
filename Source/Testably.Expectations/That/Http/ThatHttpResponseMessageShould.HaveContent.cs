#if NET6_0_OR_GREATER
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageShould
{
	/// <summary>
	///     Verifies that the string content is equal to <paramref name="expected" />
	/// </summary>
	public static StringMatcherResult<HttpResponseMessage, IThat<HttpResponseMessage?>>
		HaveContent(
			this IThat<HttpResponseMessage?> source,
			StringMatcher expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new HasContentConstraint(expected))
				.AppendMethodStatement(nameof(HaveContent), doNotPopulateThisValue),
			source,
			expected);

	private readonly struct HasContentConstraint(StringMatcher expected)
		: IAsyncConstraint<HttpResponseMessage>
	{
		public async Task<ConstraintResult> IsMetBy(
			HttpResponseMessage? actual,
			CancellationToken cancellationToken)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
					"found <null>");
			}

			string message = await actual.Content.ReadAsStringAsync(cancellationToken);
			if (expected.Matches(message))
			{
				return new ConstraintResult.Success<HttpResponseMessage?>(actual, ToString());
			}

			return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
				expected.GetExtendedFailure(message));
		}

		public override string ToString()
			=> $"have a string content {expected.GetExpectation(StringMatcher.GrammaticVoice.PassiveVoice)}";
	}
}
#endif
