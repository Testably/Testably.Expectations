#if NET6_0_OR_GREATER
using System.Net.Http;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start expectations for the current <see cref="HttpResponseMessage" /> <paramref name="subject" />.
	/// </summary>
	public static That<HttpResponseMessage?> That(HttpResponseMessage? subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<HttpResponseMessage?>(subject, doNotPopulateThisValue));
}
#endif
