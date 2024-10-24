using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatQuantifiableCollectionShould
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, That<TCollection>> Be<TItem, TCollection>(
		this QuantifiableCollection<TItem, TCollection> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
		=> new(source.Collection.ExpectationBuilder.Add(
				new AreEqualConstraint<TItem, TCollection>(expected, source.Quantity),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source.Collection);

	private readonly struct AreEqualConstraint<TItem, TCollection>(
		TItem expected,
		CollectionQuantifier quantifier)
		: IContextConstraint<TCollection>
		where TCollection : IEnumerable<TItem>
	{
		public ConstraintResult IsMetBy(TCollection actual, IEvaluationContext context)
		{
			if (actual is ICollection<TItem> collection)
			{
				TItem e = expected;
				if (!quantifier.CheckCondition(collection.Count,
					collection.Count(a => a?.Equals(e) == true), out string? error))
				{
					return new ConstraintResult.Failure(ToString(), $"{error} items were equal");
				}
			}
			else if (!quantifier.CheckCondition(
				context.UseMaterializedEnumerable<TItem, TCollection>(actual),
				expected,
				(a, e) => a?.Equals(e) == true,
				out string? error))
			{
				return new ConstraintResult.Failure(ToString(), $"{error} items were equal");
			}

			return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
		}

		public override string ToString()
			=> $"have {quantifier} equal to {Formatter.Format(expected)}";
	}
}
