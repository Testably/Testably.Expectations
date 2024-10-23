using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start delegate expectations on the current enumerable of <typeparamref name="TItem" /> values.
	/// </summary>
	public static That<IEnumerable<TItem>> Should<TItem>(this IExpectThat<IEnumerable<TItem>> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<IEnumerable<TItem>>(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start delegate expectations on the current collection of <typeparamref name="TItem" /> values.
	/// </summary>
	public static That<ICollection<TItem>> Should<TItem>(this IExpectThat<ICollection<TItem>> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<ICollection<TItem>>(subject.ExpectationBuilder);
	}
}
