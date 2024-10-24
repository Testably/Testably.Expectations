using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatQuantifiableCollectionShould
{
	/// <summary>
	///     ...satisfy the <paramref name="predicate" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, That<TCollection>>
		Satisfy<TItem, TCollection>(
			this QuantifiableCollection<TItem, TCollection> source,
			Func<TItem, bool> predicate,
			[CallerArgumentExpression("predicate")]
			string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
		=> new(source.Collection.ExpectationBuilder.Add(
				new SatisfyConstraint<TItem, TCollection>(predicate, doNotPopulateThisValue,
					source.Quantity),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source.Collection);

	private readonly struct SatisfyConstraint<TItem, TCollection>(
		Func<TItem, bool> predicate,
		string expression,
		CollectionQuantifier quantifier) : IConstraint<TCollection>
		where TCollection : IEnumerable<TItem>
	{
		public ConstraintResult IsMetBy(TCollection actual)
		{
			List<TItem> list = actual.ToList();
			int count = 0;
			foreach (TItem? item in list)
			{
				if (predicate(item))
				{
					count++;
				}
			}

			if (quantifier.CheckCondition(list.Count, count, out string? error))
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {error} items");
		}

		public override string ToString()
			=> $"have {quantifier} items satisfying {Formatter.Format(expression)}";
	}
}
