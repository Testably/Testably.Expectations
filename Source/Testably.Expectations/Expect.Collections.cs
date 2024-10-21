using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start delegate expectations on the current enumerable of <typeparamref name="TItem" /> values.
	/// </summary>
	public static That<IEnumerable<TItem>> That<TItem>(IEnumerable<TItem> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<IEnumerable<TItem>>(
			MaterializingEnumerable<TItem>.Wrap(subject), doNotPopulateThisValue));

	/// <summary>
	///     Start delegate expectations on the current collection of <typeparamref name="TItem" /> values.
	/// </summary>
	public static That<ICollection<TItem>> That<TItem>(ICollection<TItem> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ICollection<TItem>>(subject, doNotPopulateThisValue));
}
