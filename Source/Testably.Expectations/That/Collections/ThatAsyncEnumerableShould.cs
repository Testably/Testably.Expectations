#if NET6_0_OR_GREATER
using System.Collections.Generic;
using Testably.Expectations.Core;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="IAsyncEnumerable{T}" />.
/// </summary>
public static partial class ThatAsyncEnumerableShould
{
	/// <summary>
	///     Start delegate expectations on the current async enumerable of <typeparamref name="TItem" /> values.
	/// </summary>
	public static EnumerableOption<TItem, IAsyncEnumerable<TItem>> Should<TItem>(
		this IExpectSubject<IAsyncEnumerable<TItem>> subject)
		=> new(subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should))).ExpectationBuilder);
}

public class EnumerableOption<TItem, TCollection>(ExpectationBuilder expectationBuilder) : IThat<TCollection>
{
	/// <inheritdoc />
	public ExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;

	public int Limit { get; private set; }

	public IThat<TCollection> WithOptions(int limit)
	{
		Limit = limit;
		return this;
	}
}

#endif
