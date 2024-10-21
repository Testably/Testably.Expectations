#if NET6_0_OR_GREATER
using System.Net.Http;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageExtensions
{
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
			=> $"has a string content {expected.GetExpectation(GrammaticVoice.PassiveVoice)}";
	}
}
#endif
