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
	///     Verifies that the response has a client error status code (4xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HaveClientError(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 400 && statusCode < 500,
					"have client error (status code 4xx)"),
				b => b.AppendMethod(nameof(HaveClientError))),
			source);
}
#endif
