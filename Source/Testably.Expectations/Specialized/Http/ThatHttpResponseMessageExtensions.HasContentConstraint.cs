using System.Net.Http;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageExtensions
{
	private readonly struct HasContentConstraint(StringMatcher expected)
		: IConstraint<HttpResponseMessage>
	{
		public ConstraintResult IsMetBy(HttpResponseMessage? actual)
		{
			string? message = actual?.Content.ReadAsStringAsync().Result;
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
