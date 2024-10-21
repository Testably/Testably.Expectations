using System;
using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Collections;

public partial class QuantifiableCollection<TItem, TCollection>
{
	private readonly struct SatisfyConstraint(
		Func<TItem, bool> predicate,
		string expression,
		CollectionQuantifier quantifier) : IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
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
			=> $"has {quantifier} items satisfying {Formatter.Format(expression)}";
	}
}
