using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Collections;

public partial class QuantifiableCollection<TItem>
{
	private readonly struct AreEqualConstraint(TItem expected, Quantifier quantifier)
		: IExpectation<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem> list = actual.ToList();
			int count = 0;
			foreach (TItem? item in list)
			{
				if (item?.Equals(expected) == true)
				{
					count++;
				}
			}

			if (quantifier.CheckCondition(list.Count, count, out string? error))
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"{error} items were equal");
		}

		public override string ToString()
			=> $"has {quantifier} equal to {Formatter.Format(expected)}";
	}
}
