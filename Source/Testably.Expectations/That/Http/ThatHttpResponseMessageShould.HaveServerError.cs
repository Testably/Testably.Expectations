#if NET6_0_OR_GREATER
using System.Net.Http;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageShould
{
	/// <summary>
	///     Verifies that the response has a server error status code (5xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HaveServerError(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 500 && statusCode < 600,
					"have server error (status code 5xx)"),
				b => b.AppendMethod(nameof(HaveServerError))),
			source);
}
#endif
