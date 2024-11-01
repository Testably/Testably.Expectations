using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Results;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     A quantifiable result matching items against the expected
///     <see cref="QuantifiedCollectionResult{TResult}.Quantity" />.
/// </summary>
public class SyncQuantifiedCollectionResult<TResult, TItem, TCollection>(
	TResult result,
	ExpectationBuilder expectationBuilder,
	CollectionQuantifier quantity)
	: QuantifiedCollectionResult<TResult>(result, expectationBuilder, quantity)
	where TCollection : IEnumerable<TItem>
	where TResult : IThat<TCollection>
{
	/// <summary>
	///     ...are of type <typeparamref name="TExpected" />.
	/// </summary>
	public AndOrExpectationResult<TCollection, IThat<TCollection>> Be<TExpected>()
		=> new(ExpectationBuilder
				.AddConstraint(
					new BeOfTypeConstraint<TExpected>(
						Quantity,
						(a, c) => Quantity.GetEvaluator<TItem, TCollection>(a, c)))
				.AppendGenericMethodStatement<TExpected>(nameof(Be)),
			Result);

	private readonly struct BeOfTypeConstraint<TExpected>(
		CollectionQuantifier quantifier,
		Func<TCollection, IEvaluationContext, ICollectionEvaluator<TItem>> evaluatorFactory)
		: IAsyncContextConstraint<TCollection>
	{
		public async Task<ConstraintResult> IsMetBy(TCollection actual, IEvaluationContext context)
		{
			ICollectionEvaluator<TItem> evaluator = evaluatorFactory(actual, context);
			CollectionEvaluatorResult result = await evaluator
				.CheckCondition(default(TItem), (a, _) => a is TExpected)
				.ConfigureAwait(false);

			if (result.IsSuccess)
			{
				return new ConstraintResult.Success<TCollection>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				$"{result.Error} items were");
		}

		public override string ToString()
			=> $"have {quantifier} of type {typeof(TExpected).Name}";
	}
}
