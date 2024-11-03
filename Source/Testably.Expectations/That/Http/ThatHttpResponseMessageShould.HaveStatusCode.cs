#if NET6_0_OR_GREATER
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageShould
{
	/// <summary>
	///     Verifies that the response has a status code equal to <paramref name="expected" />
	/// </summary>
	public static AndOrResult<HttpResponseMessage, IThat<HttpResponseMessage?>>
		HaveStatusCode(
			this IThat<HttpResponseMessage?> source,
			HttpStatusCode expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new HasStatusCodeConstraint(expected))
				.AppendMethodStatement(nameof(HaveContent), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the response has a status code different to <paramref name="unexpected" />
	/// </summary>
	public static AndOrResult<HttpResponseMessage, IThat<HttpResponseMessage?>>
		NotHaveStatusCode(
			this IThat<HttpResponseMessage?> source,
			HttpStatusCode unexpected,
			[CallerArgumentExpression("unexpected")]
			string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new HasStatusCodeRangeConstraint(
					statusCode => statusCode != (int)unexpected,
					$"has StatusCode different to {Formatter.Format(unexpected)}"))
				.AppendMethodStatement(nameof(NotHaveStatusCode), doNotPopulateThisValue),
			source);

	private readonly struct HasStatusCodeConstraint(HttpStatusCode expected)
		: IAsyncConstraint<HttpResponseMessage>
	{
		public async Task<ConstraintResult> IsMetBy(
			HttpResponseMessage? actual,
			CancellationToken cancellationToken)
		{
			if (actual == null)
			{
				return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
					"found <null>");
			}

			if (actual.StatusCode == expected)
			{
				return new ConstraintResult.Success<HttpResponseMessage?>(actual, ToString());
			}

			string formattedResponse =
				await HttpResponseMessageFormatter.Format(actual, "  ", cancellationToken);
			return new ConstraintResult.Failure<HttpResponseMessage?>(actual, ToString(),
				$"found {Formatter.Format(actual.StatusCode)}:{Environment.NewLine}{formattedResponse}");
		}

		public override string ToString()
			=> $"have StatusCode {Formatter.Format(expected)}";
	}
}
#endif
