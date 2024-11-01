﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatQuantifiedCollectionResultShouldSync
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> Be<TItem, TCollection>(
		this QuantifiedCollectionResult<IThat<TCollection>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiedCollectionResultShould.BeEqualConstraint<TItem, TCollection>(
						expected,
						source.Quantity,
						(a, c) => source.Quantity.GetEvaluator<TItem, TCollection>(a, c)))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source.Result);
}

#if NET6_0_OR_GREATER
public static partial class ThatQuantifiedCollectionResultShouldAsync
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> Be<TItem, TCollection>(
		this QuantifiedCollectionResult<IThat<TCollection>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IAsyncEnumerable<TItem>
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiedCollectionResultShould.BeEqualConstraint<TItem, TCollection>(
						expected,
						source.Quantity,
						(a, c) => source.Quantity.GetAsyncEvaluator<TItem, TCollection>(a, c)))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source.Result);
}
#endif

public static partial class ThatQuantifiedCollectionResultShould
{
	internal readonly struct BeEqualConstraint<TItem, TCollection>(
		TItem expected,
		CollectionQuantifier quantifier,
		Func<TCollection, IEvaluationContext, ICollectionEvaluator<TItem>> evaluatorFactory)
		: IAsyncContextConstraint<TCollection>
	{
		public async Task<ConstraintResult> IsMetBy(TCollection actual, IEvaluationContext context)
		{
			ICollectionEvaluator<TItem> evaluator = evaluatorFactory(actual, context);
			CollectionEvaluatorResult result = await evaluator
				.CheckCondition(expected, (a, e) => a?.Equals(e) == true)
				.ConfigureAwait(false);

			if (result.IsSuccess)
			{
				return new ConstraintResult.Success<TCollection>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"{result.Error} items were equal");
		}

		public override string ToString()
			=> $"have {quantifier} equal to {Formatter.Format(expected)}";
	}
}