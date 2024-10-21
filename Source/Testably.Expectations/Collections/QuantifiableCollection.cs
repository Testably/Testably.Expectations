using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

namespace Testably.Expectations.Collections;

/// <summary>
///     A quantifiable collection matching items against the expected <paramref name="quantity" />.
/// </summary>
public partial class QuantifiableCollection<TItem, TCollection>(
	That<TCollection> source,
	CollectionQuantifier quantity)
	where TCollection : IEnumerable<TItem>
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public AndOrExpectationResult<TCollection, That<TCollection>> Are(
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new AreEqualConstraint(expected, quantity),
				b => b.AppendMethod(nameof(Are), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     ...are equivalent to <paramref name="expected" />.
	/// </summary>
	public EquivalencyOptionsExpectationResult<TCollection, That<TCollection>> AreEquivalentTo(
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		var options = new EquivalencyOptions();
		return new EquivalencyOptionsExpectationResult<TCollection, That<TCollection>>(
			source.ExpectationBuilder.Add(new AreEquivalentToConstraint(expected, doNotPopulateThisValue, quantity, options),
				b => b.AppendMethod(nameof(AreEquivalentTo), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     ...satisfy the <paramref name="predicate" />.
	/// </summary>
	public AndOrExpectationResult<TCollection, That<TCollection>> Satisfy(
		Func<TItem, bool> predicate,
		[CallerArgumentExpression("predicate")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new SatisfyConstraint(predicate, doNotPopulateThisValue, quantity),
				b => b.AppendMethod(nameof(Are), doNotPopulateThisValue)),
			source);
}
