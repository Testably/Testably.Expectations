using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Equivalency;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Collections;

public partial class QuantifiableCollection<TItem>
{
	private readonly struct AreEquivalentToConstraint(
		TItem expected,
		string expectedExpression,
		CollectionQuantifier quantifier,
		EquivalencyOptions options)
		: IConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem> list = actual.ToList();
			int count = 0;
			foreach (TItem? item in list)
			{
				IEnumerable<ComparisonFailure> failures = Compare.CheckEquivalent(item, expected,
					new CompareOptions
					{
						MembersToIgnore = [.. options.MembersToIgnore],
					});
				if (!failures.Any())
				{
					count++;
				}
			}

			if (quantifier.CheckCondition(list.Count, count, out string? error))
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"{error} items were equivalent");
		}

		public override string ToString()
			=> $"has {quantifier} equivalent to {expectedExpression}";
	}
}
