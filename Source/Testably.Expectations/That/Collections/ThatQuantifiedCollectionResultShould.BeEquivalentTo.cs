using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Equivalency;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatQuantifiedCollectionResultShouldSync
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> BeEquivalentTo<TItem,
		TCollection>(
		this QuantifiedCollectionResult<IThat<TCollection>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
	{
		EquivalencyOptions options = new();
		return new AndOrExpectationResult<TCollection, IThat<TCollection>>(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiedCollectionResultShould.BeEquivalentToConstraint<TItem, TCollection>(
						expected,
						doNotPopulateThisValue,
						source.Quantity,
						options,
						(a, c) => new CollectionAccessor<TItem>(a, c)))
				.AppendMethodStatement(nameof(BeEquivalentTo), doNotPopulateThisValue),
			source.Result);
	}
}

#if NET6_0_OR_GREATER
public static partial class ThatQuantifiedCollectionResultShouldAsync
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> BeEquivalentTo<TItem,
		TCollection>(
		this QuantifiedCollectionResult<IThat<TCollection>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IAsyncEnumerable<TItem>
	{
		EquivalencyOptions options = new();
		return new AndOrExpectationResult<TCollection, IThat<TCollection>>(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiedCollectionResultShould.BeEquivalentToConstraint<TItem, TCollection>(
						expected,
						doNotPopulateThisValue,
						source.Quantity,
						options,
						(a, c) => new CollectionAccessor<TItem>(a, c)))
				.AppendMethodStatement(nameof(BeEquivalentTo), doNotPopulateThisValue),
			source.Result);
	}
}
#endif

public static partial class ThatQuantifiedCollectionResultShould
{
	internal readonly struct BeEquivalentToConstraint<TItem, TCollection>(
		TItem expected,
		string expectedExpression,
		CollectionQuantifier quantifier,
		EquivalencyOptions options,
		Func<TCollection, IEvaluationContext, CollectionAccessor<TItem>> factory)
		: IAsyncContextConstraint<TCollection>
	{
		public async Task<ConstraintResult> IsMetBy(TCollection actual, IEvaluationContext context)
		{
			string[] memberToIgnore = [.. options.MembersToIgnore];
			CollectionAccessor<TItem> accessor = factory(actual, context);
			(bool, string) result = await accessor
				.CheckCondition(quantifier, expected, (a, e) => !Compare.CheckEquivalent(a, e,
					new CompareOptions
					{
						MembersToIgnore = memberToIgnore,
					}).Any())
				.ConfigureAwait(false);

			if (result.Item1)
			{
				return new ConstraintResult.Success<TCollection>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"{result.Item2} items were equivalent");
		}

		public override string ToString()
			=> $"have {quantifier} equivalent to {expectedExpression}";
	}
}
