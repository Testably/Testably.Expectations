using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
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
	public static IThat<object?> Should(this IExpectSubject<object?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));
}
