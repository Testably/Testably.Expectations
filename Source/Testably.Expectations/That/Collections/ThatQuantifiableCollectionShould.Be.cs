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

public static partial class ThatQuantifiableCollectionShould
{
	/// <summary>
	///     ...are equal to <paramref name="expected" />.
	/// </summary>
	public static AndOrExpectationResult<TCollection, IThat<TCollection>> Be<TItem, TCollection>(
		this QuantifiableCollection<TItem, TCollection> source,
		TItem expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TCollection : IEnumerable<TItem>
		=> new(source.Collection.ExpectationBuilder
				.AddConstraint(
					new AreEqualConstraint<TItem, TCollection>(expected, source.Quantity))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source.Collection);

	private readonly struct AreEqualConstraint<TItem, TCollection>(
		TItem expected,
		CollectionQuantifier quantifier)
		: IAsyncContextConstraint<TCollection>
		where TCollection : IEnumerable<TItem>
	{
		public async Task<ConstraintResult> IsMetBy(TCollection actual, IEvaluationContext context)
		{
			CollectionAccessor<TItem>? accessor = new(actual, context);
			(bool, string) result = await accessor
				.CheckCondition(quantifier, expected, (a, e) => a?.Equals(e) == true)
				.ConfigureAwait(false);

			if (result.Item1)
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"{result.Item2} items were equal");
		}

		public override string ToString()
			=> $"have {quantifier} equal to {Formatter.Format(expected)}";
	}
}
