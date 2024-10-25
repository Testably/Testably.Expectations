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
	///     Verifies that the response has a redirection status code (3xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		BeRedirection(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 300 && statusCode < 400,
					"be redirection (status code 3xx)"),
				b => b.AppendMethod(nameof(BeRedirection))),
			source);
}
#endif
