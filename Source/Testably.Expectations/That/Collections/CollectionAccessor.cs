using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.That.Collections;

internal class CollectionAccessor<TItem>
{
	private readonly IEnumerable<TItem>? _enumerable;

	public CollectionAccessor(IEnumerable<TItem> enumerable, IEvaluationContext context)
	{
		_enumerable = context.UseMaterializedEnumerable<TItem, IEnumerable<TItem>>(enumerable);
	}

	public async Task<(bool, string)> CheckCondition<TExpected>(
		CollectionQuantifier quantifier,
		TExpected expected,
		Func<TItem, TExpected, bool> predicate)
	{
		int matchingCount = 0;
		int notMatchingCount = 0;
		int? totalCount = (_enumerable as ICollection<TItem>)?.Count;

		if (_enumerable != null)
		{
			foreach (TItem item in _enumerable)
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
					out (bool, string)? result))
				{
					return result.Value;
				}
			}
		}
#if NET6_0_OR_GREATER
		else if (_asyncEnumerable != null)
		{
			await foreach (TItem item in _asyncEnumerable)
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
					out (bool, string)? result))
				{
					return result.Value;
				}
			}
		}
#else
		await Task.Yield();
#endif
		return !quantifier.ContinueEvaluation(
			matchingCount, notMatchingCount, matchingCount + notMatchingCount,
			out (bool, string)? finalResult)
			? finalResult.Value
			: (false, "could not decide");
	}

#if NET6_0_OR_GREATER
	private readonly IAsyncEnumerable<TItem>? _asyncEnumerable;
	public CollectionAccessor(IAsyncEnumerable<TItem> asyncEnumerable, IEvaluationContext context)
	{
		_asyncEnumerable =
			context.UseMaterializedAsyncEnumerable<TItem, IAsyncEnumerable<TItem>>(asyncEnumerable);
		;
	}
#endif
}
