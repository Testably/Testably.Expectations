using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Equivalency;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatQuantifiableCollectionShould
{
	/// <summary>
	///     ...are equivalent to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> BeEquivalentTo<TItem,
		TCollection>(
		this QuantifiableCollection<TItem, TCollection> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
	{
		EquivalencyOptions options = new();
		return new AndOrExpectationResult<TCollection, IThat<TCollection>>(
			source.Collection.ExpectationBuilder
				.AddConstraint(
				new AreEquivalentToConstraint<TItem, TCollection>(expected, doNotPopulateThisValue,
					source.Quantity, options))
				.AppendMethodStatement(nameof(BeEquivalentTo), doNotPopulateThisValue),
			source.Collection);
	}

	private readonly struct AreEquivalentToConstraint<TItem, TCollection>(
		TItem expected,
		string expectedExpression,
		CollectionQuantifier quantifier,
		EquivalencyOptions options)
		: IContextConstraint<TCollection>
		where TCollection : IEnumerable<TItem>
	{
		public ConstraintResult IsMetBy(TCollection actual, IEvaluationContext context)
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
			=> $"have {quantifier} equivalent to {expectedExpression}";
	}
}
