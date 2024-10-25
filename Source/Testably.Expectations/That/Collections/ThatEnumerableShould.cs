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
	public static That<IEnumerable<TItem>> Should<TItem>(
		this IExpectThat<IEnumerable<TItem>> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<IEnumerable<TItem>>(subject.ExpectationBuilder);
	}
}
