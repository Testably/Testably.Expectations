#if NET6_0_OR_GREATER
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageExtensions
{
	private readonly struct HasStatusCodeRangeConstraint(Func<int, bool> predicate, string expectation)
		: IAsyncConstraint<HttpResponseMessage>
	{
		public async Task<ConstraintResult> IsMetBy(HttpResponseMessage? actual)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
					"found <null>");
			}

			if (predicate((int)actual.StatusCode))
			{
				return new ConstraintResult.Success<HttpResponseMessage?>(actual, ToString());
			}

			string formattedResponse = await HttpResponseMessageFormatter.Format(actual, "  ");
			return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
				$"found {Formatter.Format(actual.StatusCode)}:{Environment.NewLine}{formattedResponse}");
		}

		public override string ToString()
			=> expectation;
	}
}
#endif
