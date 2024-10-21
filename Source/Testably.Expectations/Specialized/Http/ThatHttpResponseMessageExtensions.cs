#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="HttpResponseMessage" /> values.
/// </summary>
public static partial class ThatHttpResponseMessageExtensions
{
	/// <summary>
	///     Verifies that the response has a status code different to <paramref name="unexpected" />
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		DoesNotHaveStatusCode(
			this That<HttpResponseMessage?> source,
			HttpStatusCode unexpected,
			[CallerArgumentExpression("unexpected")]
			string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(statusCode => statusCode != (int)unexpected,
					$"has StatusCode different to {Formatter.Format(unexpected)}"),
				b => b.AppendMethod(nameof(DoesNotHaveStatusCode), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the response has a client error status code (4xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HasClientError(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 400 && statusCode < 500,
					"has client error (status code 4xx)"),
				b => b.AppendMethod(nameof(HasClientError))),
			source);

	/// <summary>
	///     Verifies that the string content is equal to <paramref name="expected" />
	/// </summary>
	public static StringMatcherExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HasContent(
			this That<HttpResponseMessage?> source,
			StringMatcher expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new HasContentConstraint(expected),
				b => b.AppendMethod(nameof(HasContent), doNotPopulateThisValue)),
			source,
			expected);

	/// <summary>
	///     Verifies that the response has a client or server error status code (4xx or 5xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HasError(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 400 && statusCode < 600,
					"has an error (status code 4xx or 5xx)"),
				b => b.AppendMethod(nameof(HasError))),
			source);

	/// <summary>
	///     Verifies that the response has a server error status code (5xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HasServerError(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 500 && statusCode < 600,
					"has server error (status code 5xx)"),
				b => b.AppendMethod(nameof(HasServerError))),
			source);

	/// <summary>
	///     Verifies that the response has a status code equal to <paramref name="expected" />
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		HasStatusCode(
			this That<HttpResponseMessage?> source,
			HttpStatusCode expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeConstraint(expected),
				b => b.AppendMethod(nameof(HasContent), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the response has a redirection status code (3xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		IsRedirection(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 300 && statusCode < 400,
					"is redirection (status code 3xx)"),
				b => b.AppendMethod(nameof(IsRedirection))),
			source);

	/// <summary>
	///     Verifies that the response has a success status code (2xx)
	/// </summary>
	public static AndOrExpectationResult<HttpResponseMessage, That<HttpResponseMessage?>>
		IsSuccessful(
			this That<HttpResponseMessage?> source)
		=> new(source.ExpectationBuilder.Add(
				new HasStatusCodeRangeConstraint(
					statusCode => statusCode >= 200 && statusCode < 300,
					"is successful (status code 2xx)"),
				b => b.AppendMethod(nameof(IsSuccessful))),
			source);
}
#endif
