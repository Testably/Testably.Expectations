﻿#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Linq;
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
	///     Verifies that the actual enumerable is empty.
	/// </summary>
	public static AndOrExpectationResult<IAsyncEnumerable<TItem>, IThat<IAsyncEnumerable<TItem>>>
		BeEmpty<TItem>(
			this IThat<IAsyncEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsEmptyValueConstraint<TItem>())
				.AppendMethodStatement(nameof(BeEmpty)),
			source);

	/// <summary>
	///     Verifies that the actual enumerable is not empty.
	/// </summary>
	public static AndOrExpectationResult<IAsyncEnumerable<TItem>, IThat<IAsyncEnumerable<TItem>>>
		NotBeEmpty<TItem>(
			this IThat<IAsyncEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotEmptyConstraint<TItem>())
				.AppendMethodStatement(nameof(NotBeEmpty)),
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
			IEnumerable<TItem>? materializedEnumerable =
				context.UseMaterializedEnumerable<TItem, IEnumerable<TItem>>(actual);
			using IEnumerator<TItem> enumerator = materializedEnumerable.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return new ConstraintResult.Success<IEnumerable<TItem>>(materializedEnumerable,
					ToString());
			}

			return new ConstraintResult.Failure(ToString(), "it was");
		}

		public override string ToString()
			=> "not be empty";
	}
}
#endif