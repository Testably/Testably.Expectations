using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start delegate expectations on the current enumerable of <typeparamref name="TItem" /> values.
	/// </summary>
	public static That<IEnumerable<TItem>> Should<TItem>(this ExpectThat<IEnumerable<TItem>> subject)
		=> new(subject.ExpectationBuilder);

	/// <summary>
	///     Start delegate expectations on the current collection of <typeparamref name="TItem" /> values.
	/// </summary>
	public static That<ICollection<TItem>> Should<TItem>(this ExpectThat<ICollection<TItem>> subject)
		=> new(subject.ExpectationBuilder);
}
