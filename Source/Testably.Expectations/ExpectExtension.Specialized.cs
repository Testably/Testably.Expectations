﻿#if NET6_0_OR_GREATER
using System.Net.Http;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start expectations for the current <see cref="HttpResponseMessage" /> <paramref name="subject" />.
	/// </summary>
	public static That<HttpResponseMessage?> Should(this IExpectThat<HttpResponseMessage?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<HttpResponseMessage?>(subject.ExpectationBuilder);
	}
}
#endif