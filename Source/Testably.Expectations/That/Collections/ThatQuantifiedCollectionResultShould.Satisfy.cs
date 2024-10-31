using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatQuantifiedCollectionResultShouldSync
{
	/// <summary>
	///     ...satisfy the <paramref name="predicate" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>>
		Satisfy<TItem, TCollection>(
			this QuantifiedCollectionResult<IThat<TCollection>> source,
			Func<TItem, bool> predicate,
			[CallerArgumentExpression("predicate")]
			string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiedCollectionResultShould.SatisfyConstraint<TItem, TCollection>(
						predicate,
						doNotPopulateThisValue,
						source.Quantity,
						(a, c) => source.Quantity.GetEvaluator<TItem, TCollection>(a, c)))
				.AppendMethodStatement(nameof(Satisfy), doNotPopulateThisValue),
			source.Result);
}

#if NET6_0_OR_GREATER
public static partial class ThatQuantifiedCollectionResultShouldAsync
{
	/// <summary>
	///     ...satisfy the <paramref name="predicate" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>>
		Satisfy<TItem, TCollection>(
			this QuantifiedCollectionResult<IThat<TCollection>> source,
			Func<TItem, bool> predicate,
			[CallerArgumentExpression("predicate")]
			string doNotPopulateThisValue = "")
		where TCollection : IAsyncEnumerable<TItem>
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiedCollectionResultShould.SatisfyConstraint<TItem, TCollection>(
						predicate,
						doNotPopulateThisValue,
						source.Quantity,
						(a, c) => source.Quantity.GetAsyncEvaluator<TItem, TCollection>(a, c)))
				.AppendMethodStatement(nameof(Satisfy), doNotPopulateThisValue),
			source.Result);
}
#endif

public static partial class ThatQuantifiedCollectionResultShould
{
	internal readonly struct SatisfyConstraint<TItem, TCollection>(
		Func<TItem, bool> predicate,
		string expression,
		CollectionQuantifier quantifier,
		Func<TCollection, IEvaluationContext, ICollectionEvaluator<TItem>> evaluatorFactory)
		: IAsyncContextConstraint<TCollection>
	{
		public async Task<ConstraintResult> IsMetBy(TCollection actual, IEvaluationContext context)
		{
			ICollectionEvaluator<TItem> evaluator = evaluatorFactory(actual, context);
			CollectionEvaluatorResult result = await evaluator
				.CheckCondition(predicate, (a, p) => p(a))
				.ConfigureAwait(false);

			if (result.IsSuccess)
			{
				return new ConstraintResult.Success<TCollection>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {result.Error} items");
		}

		public override string ToString()
			=> $"have {quantifier} items satisfying {Formatter.Format(expression)}";
	}
}
