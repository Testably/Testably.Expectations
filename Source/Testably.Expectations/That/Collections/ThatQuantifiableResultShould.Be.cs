﻿using System;
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

public static partial class ThatQuantifiableResultShouldSync
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> Be<TItem, TCollection>(
		this QuantifiableResult<IThat<TCollection>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiableResultShould.BeEqualConstraint<TItem, TCollection>(expected,
						source.Quantity,
						(a, c) => new CollectionAccessor<TItem>(a, c)))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source.Result);
}

#if NET6_0_OR_GREATER
public static partial class ThatQuantifiableResultShouldAsync
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> Be<TItem, TCollection>(
		this QuantifiableResult<IThat<TCollection>> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IAsyncEnumerable<TItem>
		=> new(source.ExpectationBuilder
				.AddConstraint(
					new ThatQuantifiableResultShould.BeEqualConstraint<TItem, TCollection>(expected,
						source.Quantity,
						(a, c) => new CollectionAccessor<TItem>(a, c)))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source.Result);
}
#endif

public static partial class ThatQuantifiableResultShould
{
	internal readonly struct BeEqualConstraint<TItem, TCollection>(
		TItem expected,
		CollectionQuantifier quantifier,
		Func<TCollection, IEvaluationContext, CollectionAccessor<TItem>> factory)
		: IAsyncContextConstraint<TCollection>
	{
		public async Task<ConstraintResult> IsMetBy(TCollection actual, IEvaluationContext context)
		{
			CollectionAccessor<TItem> accessor = factory(actual, context);
			(bool, string) result = await accessor
				.CheckCondition(quantifier, expected, (a, e) => a?.Equals(e) == true)
				.ConfigureAwait(false);

			if (result.Item1)
			{
				return new ConstraintResult.Success<TCollection>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"{result.Item2} items were equal");
		}

		public override string ToString()
			=> $"have {quantifier} equal to {Formatter.Format(expected)}";
	}
}
