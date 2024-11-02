﻿#if NET6_0_OR_GREATER
using System.Net.Http;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageShould
{
	/// <summary>
	///     Verifies that the response has a redirection status code (3xx)
	/// </summary>
	public static AndOrResult<HttpResponseMessage, IThat<HttpResponseMessage?>>
		BeRedirection(
			this IThat<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 300 && statusCode < 400,
					"be redirection (status code 3xx)"))
				.AppendMethodStatement(nameof(BeRedirection)),
			source);
}
#endif
