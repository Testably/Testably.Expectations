using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
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
}
