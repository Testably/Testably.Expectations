#if NET6_0_OR_GREATER
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageShould
{
	/// <summary>
	///     Verifies that the string content is equal to <paramref name="expected" />
	/// </summary>
	public static StringMatcherExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HaveContent(
			this That<HttpResponseMessage?> source,
			StringMatcher expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new HasContentConstraint(expected),
				b => b.AppendMethod(nameof(HaveContent), doNotPopulateThisValue)),
			source,
			expected);

	private readonly struct HasContentConstraint(StringMatcher expected)
		: IAsyncConstraint<HttpResponseMessage>
	{
		public async Task<ConstraintResult> IsMetBy(HttpResponseMessage? actual)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
					"found <null>");
			}

			string message = await actual.Content.ReadAsStringAsync();
			if (expected.Matches(message))
			{
				return new ConstraintResult.Success<HttpResponseMessage?>(actual, ToString());
			}

			return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
				expected.GetExtendedFailure(message));
		}

		public override string ToString()
			=> $"have a string content {expected.GetExpectation(GrammaticVoice.PassiveVoice)}";
	}
}
#endif
