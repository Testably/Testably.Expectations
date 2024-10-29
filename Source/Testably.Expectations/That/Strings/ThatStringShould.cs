using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="string" /> values.
/// </summary>
public static partial class ThatStringShould
{
	/// <summary>
	///     Start expectations for the current <see cref="string" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<string?> Should(this IExpectSubject<string?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<string?>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));
}
