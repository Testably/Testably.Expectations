using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that the actual enumerable is empty.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<TItem>, IThat<IEnumerable<TItem>>>
		BeEmpty<TItem>(
			this IThat<IEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsEmptyValueConstraint<TItem>(),
				b => b.AppendMethod(nameof(BeEmpty))),
			source);

	/// <summary>
	///     Verifies that the actual enumerable is not empty.
	/// </summary>
	public static AndOrExpectationResult<IEnumerable<TItem>, IThat<IEnumerable<TItem>>>
		NotBeEmpty<TItem>(
			this IThat<IEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder.Add(new IsNotEmptyConstraint<TItem>(),
				b => b.AppendMethod(nameof(NotBeEmpty))),
			source);

	private readonly struct IsEmptyValueConstraint<TItem> : IValueConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual)
		{
			using IEnumerator<TItem> enumerator = actual.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return new ConstraintResult.Failure(ToString(),
					$"found {Formatter.Format(actual.Take(11))}");
			}

			return new ConstraintResult.Success<IEnumerable<TItem>>(actual, ToString());
		}

		public override string ToString()
			=> "be empty";
	}

	private readonly struct IsNotEmptyConstraint<TItem> : IContextConstraint<IEnumerable<TItem>>
	{
		public ConstraintResult IsMetBy(IEnumerable<TItem> actual, IEvaluationContext context)
		{
			var materializedEnumerable =
				context.UseMaterializedEnumerable<TItem, IEnumerable<TItem>>(actual);
			using IEnumerator<TItem> enumerator = materializedEnumerable.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(materializedEnumerable, ToString());
			}

			return new ConstraintResult.Failure(ToString(), "it was");
		}

		public override string ToString()
			=> "not be empty";
	}
}
