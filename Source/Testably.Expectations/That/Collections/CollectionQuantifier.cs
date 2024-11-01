using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Testably.Expectations.Core.EvaluationContext;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Quantifier for collections.
/// </summary>
public abstract partial class CollectionQuantifier
{
#if NET6_0_OR_GREATER
	/// <summary>
	///     Get an asynchronous <see cref="ICollectionEvaluator{TItem}" /> that evaluates the
	///     <paramref name="enumerable" /> asynchronously.
	/// </summary>
	public ICollectionEvaluator<TItem> GetAsyncEvaluator<TItem, TCollection>(
		TCollection enumerable,
		IEvaluationContext context)
		where TCollection : IAsyncEnumerable<TItem>
		=> new AsynchronousCollectionEvaluator<TItem>(this,
			context.UseMaterializedAsyncEnumerable<TItem, IAsyncEnumerable<TItem>>(enumerable));
#endif

	/// <summary>
	///     Get a synchronous <see cref="ICollectionEvaluator{TItem}" /> that evaluates the
	///     <paramref name="enumerable" />.
	/// </summary>
	public ICollectionEvaluator<TItem> GetEvaluator<TItem, TCollection>(
		TCollection enumerable,
		IEvaluationContext context)
		where TCollection : IEnumerable<TItem>
		=> new SynchronousCollectionEvaluator<TItem>(this,
			context.UseMaterializedEnumerable<TItem, IEnumerable<TItem>>(enumerable));

	/// <summary>
	///     Returns a string representation which depending on <paramref name="includeItems" /> ends with `Items`.
	/// </summary>
	public abstract string ToString(bool includeItems);

	/// <inheritdoc />
	public override string ToString()
		=> ToString(true);

	/// <summary>
	///     Checks for each iteration, if the evaluation should continue.
	/// </summary>
	protected abstract bool ContinueEvaluation(
		int matchingCount,
		int notMatchingCount,
		int? totalCount,
		[NotNullWhen(false)] out CollectionEvaluatorResult? result);

	private class SynchronousCollectionEvaluator<TItem>(
		CollectionQuantifier quantifier,
		IEnumerable<TItem> enumerable)
		: ICollectionEvaluator<TItem>
	{
		#region ICollectionEvaluator<TItem> Members

		/// <inheritdoc cref="ICollectionEvaluator{TItem}.CheckCondition{TExpected}" />
		public Task<CollectionEvaluatorResult> CheckCondition<TExpected>(
			TExpected expected,
			Func<TItem, TExpected, bool> predicate)
		{
			int matchingCount = 0;
			int notMatchingCount = 0;
			int? totalCount = (enumerable as ICollection<TItem>)?.Count;

			foreach (TItem item in enumerable)
			{
				bool isMatch = predicate(item, expected);
				if (isMatch)
				{
					matchingCount++;
				}
				else
				{
					notMatchingCount++;
				}

				if (!quantifier.ContinueEvaluation(matchingCount, notMatchingCount, totalCount,
					out CollectionEvaluatorResult? result))
				{
					return Task.FromResult(result.Value);
				}
			}

			return Task.FromResult(!quantifier.ContinueEvaluation(
				matchingCount, notMatchingCount, matchingCount + notMatchingCount,
				out CollectionEvaluatorResult? finalResult)
				? finalResult.Value
				: new CollectionEvaluatorResult(false, "could not decide"));
		}

		#endregion
	}

#if NET6_0_OR_GREATER
	private class AsynchronousCollectionEvaluator<TItem>(
		CollectionQuantifier quantifier,
		IAsyncEnumerable<TItem> asyncEnumerable)
		: ICollectionEvaluator<TItem>
	{
		#region ICollectionEvaluator<TItem> Members

		/// <inheritdoc cref="ICollectionEvaluator{TItem}.CheckCondition{TExpected}" />
		public async Task<CollectionEvaluatorResult> CheckCondition<TExpected>(
			TExpected expected,
			Func<TItem, TExpected, bool> predicate)
		{
			int matchingCount = 0;
			int notMatchingCount = 0;
			int? totalCount = null;

			await foreach (TItem item in asyncEnumerable)
			{
				bool isMatch = predicate(item, expected);
				if (isMatch)
				{
					matchingCount++;
				}
				else
				{
					notMatchingCount++;
				}

				if (!quantifier.ContinueEvaluation(matchingCount, notMatchingCount, totalCount,
					out CollectionEvaluatorResult? result))
				{
					return result.Value;
				}
			}

			return !quantifier.ContinueEvaluation(
				matchingCount, notMatchingCount, matchingCount + notMatchingCount,
				out CollectionEvaluatorResult? finalResult)
				? finalResult.Value
				: new CollectionEvaluatorResult(false, "could not decide");
		}

		#endregion
	}
#endif
}
