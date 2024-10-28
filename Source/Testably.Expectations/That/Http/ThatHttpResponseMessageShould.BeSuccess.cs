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
	///     Verifies that the response has a success status code (2xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, IThat<HttpResponseMessage?>>
		BeSuccess(
			this IThat<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 200 && statusCode < 300,
					"be success (status code 2xx)"),
				b => b.AppendMethod(nameof(BeSuccess))),
			source);
}
#endif
