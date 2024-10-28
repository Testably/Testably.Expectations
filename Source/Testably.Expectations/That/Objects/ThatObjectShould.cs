using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="object" /> values.
/// </summary>
public static partial class ThatObjectShould
{
	/// <summary>
	///     Start expectations for the current <see cref="object" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<object?> Should(this IExpectThat<object?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<object?>(subject.ExpectationBuilder);
	}
}
