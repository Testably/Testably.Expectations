using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on enumerables.
/// </summary>
public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Start delegate expectations on the current enumerable of <typeparamref name="TItem" /> values.
	/// </summary>
	public static IThat<IEnumerable<TItem>> Should<TItem>(
		this IExpectThat<IEnumerable<TItem>> subject)
		=> new That<IEnumerable<TItem>>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));
}
