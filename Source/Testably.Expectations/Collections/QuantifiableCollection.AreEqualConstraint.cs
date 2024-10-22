using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

namespace Testably.Expectations.Collections;

public partial class QuantifiableCollection<TItem, TCollection>
{
	private readonly struct AreEqualConstraint(TItem expected, CollectionQuantifier quantifier)
		: IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			if (actual is ICollection<TItem> collection)
			{
				TItem e = expected;
				if (!quantifier.CheckCondition(collection.Count,
					collection.Count(a => a?.Equals(e) == true), out string? error))
				{
					return new ConstraintResult.Failure(ToString(), $"{error} items were equal");
				}
			}
			else if (!quantifier.CheckCondition(actual, expected, (a, e) => a?.Equals(e) == true,
				out string? error))
			{
				return new ConstraintResult.Failure(ToString(), $"{error} items were equal");
			}

			return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
		}

		public override string ToString()
			=> $"has {quantifier} equal to {Formatter.Format(expected)}";
	}
}
