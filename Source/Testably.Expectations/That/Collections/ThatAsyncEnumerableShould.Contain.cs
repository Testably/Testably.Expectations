#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatAsyncEnumerableShould
{
	/// <summary>
	///     Verifies that the actual enumerable contains the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<IAsyncEnumerable<TItem>, IThat<IAsyncEnumerable<TItem>>>
		Contain<TItem>(
			this IThat<IAsyncEnumerable<TItem>> source,
			TItem expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ContainsConstraint<TItem>(expected))
				.AppendMethodStatement(nameof(Contain), doNotPopulateThisValue),
			source);

	private readonly struct ContainsConstraint<TItem>(TItem expected)
		: IContextConstraint<IAsyncEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IAsyncEnumerable<TItem> actual, IEvaluationContext context)
		{
			//IAsyncEnumerable<TItem>? materializedEnumerable =
			//	context.UseMaterializedEnumerable<TItem, IAsyncEnumerable<TItem>>(actual);
			//foreach (TItem item in materializedEnumerable)
			//{
			//	if (item?.Equals(expected) == true)
			//	{
			//		return new ConstraintResult.Success<IAsyncEnumerable<TItem>>(materializedEnumerable,
			//			ToString());
			//	}
			//}

			return new ConstraintResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"contains {Formatter.Format(expected)}";
	}
}
#endif
