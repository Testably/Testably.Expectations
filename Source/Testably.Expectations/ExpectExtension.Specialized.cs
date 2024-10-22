#if NET6_0_OR_GREATER
using System.Net.Http;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start expectations for the current <see cref="HttpResponseMessage" /> <paramref name="subject" />.
	/// </summary>
	public static That<HttpResponseMessage?> Should(this ExpectThat<HttpResponseMessage?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(subject.ExpectationBuilder);
}
#endif
