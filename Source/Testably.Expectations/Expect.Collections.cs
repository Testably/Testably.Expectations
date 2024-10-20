using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class Expect
{
	///// <summary>
	/////     Start delegate assertions on the current <see cref="string" /> values.
	///// </summary>
	//public static That<IEnumerable<string>> That(IEnumerable<string> subject,
	//	[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
	//	=> new(new ExpectationBuilder<IEnumerable<string>>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start delegate assertions on the current <see cref="string" /> values.
	/// </summary>
	public static That<IEnumerable<TItem>> That<TItem>(IEnumerable<TItem> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<IEnumerable<TItem>>(subject, doNotPopulateThisValue));
}
