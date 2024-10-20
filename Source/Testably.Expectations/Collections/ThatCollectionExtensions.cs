using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Collections;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on collections.
/// </summary>
public static partial class ThatCollectionExtensions
{
	/// <summary>
	///     Verifies that all items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> All<TItem>(this That<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(All)));
		return new QuantifiableCollection<TItem>(source, CollectionQuantifier.All);
	}

	/// <summary>
	///     Verifies that at least <paramref name="minimum" /> items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> AtLeast<TItem>(this That<IEnumerable<TItem>> source,
		int minimum, [CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(AtLeast), doNotPopulateThisValue));
		return new QuantifiableCollection<TItem>(source, CollectionQuantifier.AtLeast(minimum));
	}

	/// <summary>
	///     Verifies that at most <paramref name="maximum" /> items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> AtMost<TItem>(this That<IEnumerable<TItem>> source,
		int maximum, [CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(AtMost), doNotPopulateThisValue));
		return new QuantifiableCollection<TItem>(source, CollectionQuantifier.AtMost(maximum));
	}

	/// <summary>
	///     Verifies that between <paramref name="minimum" /> and <paramref name="maximum" /> items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> Between<TItem>(this That<IEnumerable<TItem>> source,
		int minimum, int maximum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("maximum")] string doNotPopulateThisValue2 = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(Between), doNotPopulateThisValue1, doNotPopulateThisValue2));
		return new QuantifiableCollection<TItem>(source, CollectionQuantifier.Between(minimum, maximum));
	}

	/// <summary>
	///     Verifies that the actual collection contains the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<TItem>, That<IEnumerable<TItem>>>
		Contains<TItem>(
			this That<IEnumerable<TItem>> source,
			TItem expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new ContainsConstraint<TItem>(expected),
				b => b.AppendMethod(nameof(Contains), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual collection is empty.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<TItem>, That<IEnumerable<TItem>>>
		IsEmpty<TItem>(
			this That<IEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsEmptyConstraint<TItem>(),
				b => b.AppendMethod(nameof(IsEmpty))),
			source);

	/// <summary>
	///     Verifies that the actual collection is not empty.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<TItem>, That<IEnumerable<TItem>>>
		IsNotEmpty<TItem>(
			this That<IEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsNotEmptyConstraint<TItem>(),
				b => b.AppendMethod(nameof(IsNotEmpty))),
			source);

	/// <summary>
	///     Verifies that no items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem> None<TItem>(this That<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(None)));
		return new QuantifiableCollection<TItem>(source, CollectionQuantifier.None);
	}
}
