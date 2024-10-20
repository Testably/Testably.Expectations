using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

namespace Testably.Expectations.Collections;

/// <summary>
///     A quantifiable collection matching items against the expected <paramref name="quantity" />.
/// </summary>
public class QuantifiableCollection<TItem>(That<IEnumerable<TItem>> source, Quantifier quantity)
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public AssertionResult<IEnumerable<TItem>, That<IEnumerable<TItem>>> Are(
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new AreEqualExpectation(expected, quantity),
				b => b.AppendMethod(nameof(Are), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     ...are equivalent to <paramref name="expected" />.
	/// </summary>
	public AssertionResult<IEnumerable<TItem>, That<IEnumerable<TItem>>> AreEquivalentTo(
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new AreEquivalentToExpectation(expected, quantity),
				b => b.AppendMethod(nameof(Are), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     ...satisfy the <paramref name="predicate" />.
	/// </summary>
	public AssertionResult<IEnumerable<TItem>, That<IEnumerable<TItem>>> Satisfy(
		Func<TItem, bool> predicate,
		[CallerArgumentExpression("predicate")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new SatisfyExpectation(predicate, doNotPopulateThisValue, quantity),
				b => b.AppendMethod(nameof(Are), doNotPopulateThisValue)),
			source);

	private readonly struct AreEquivalentToExpectation(TItem expected, Quantifier quantifier)
		: IExpectation<IEnumerable<TItem>>
	{
		public ExpectationResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem>? list = actual.ToList();
			int count = 0;
			foreach (TItem? item in list)
			{
				//TODO Change to IsEquivalentTo
				if (item?.Equals(expected) != false)
				{
					count++;
				}
			}

			if (quantifier.CheckCondition(list.Count, count, out string? error))
			{
				return new ExpectationResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {error} items");
		}

		public override string ToString()
			=> $"has {quantifier} items equivalent to {Formatter.Format(expected)}";
	}

	private readonly struct SatisfyExpectation(
		Func<TItem, bool> predicate,
		string expression,
		Quantifier quantifier) : IExpectation<IEnumerable<TItem>>
	{
		public ExpectationResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem>? list = actual.ToList();
			int count = 0;
			foreach (TItem? item in list)
			{
				if (predicate(item))
				{
					count++;
				}
			}

			if (quantifier.CheckCondition(list.Count, count, out string? error))
			{
				return new ExpectationResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"found {error} items");
		}

		public override string ToString()
			=> $"has {quantifier} items satisfying {Formatter.Format(expression)}";
	}

	private readonly struct AreEqualExpectation(TItem expected, Quantifier quantifier)
		: IExpectation<IEnumerable<TItem>>
	{
		public ExpectationResult IsMetBy(IEnumerable<TItem> actual)
		{
			List<TItem>? list = actual.ToList();
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
				return new ExpectationResult.Success<IEnumerable<TItem>>(list, ToString());
			}

			return new ExpectationResult.Failure(ToString(), $"{error} items were equal");
		}

		public override string ToString()
			=> $"has {quantifier} equal to {Formatter.Format(expected)}";
	}
}
