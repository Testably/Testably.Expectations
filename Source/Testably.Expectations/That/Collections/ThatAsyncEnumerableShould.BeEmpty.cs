#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatAsyncEnumerableShould
{
	/// <summary>
	///     Verifies that the actual enumerable is empty.
	/// </summary>
	public static AndOrResult<IAsyncEnumerable<TItem>, IThat<IAsyncEnumerable<TItem>>>
		BeEmpty<TItem>(
			this IThat<IAsyncEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsEmptyValueConstraint<TItem>()),
			source);

	/// <summary>
	///     Verifies that the actual enumerable is not empty.
	/// </summary>
	public static AndOrResult<IAsyncEnumerable<TItem>, IThat<IAsyncEnumerable<TItem>>>
		NotBeEmpty<TItem>(
			this IThat<IAsyncEnumerable<TItem>> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotEmptyConstraint<TItem>()),
			source);

	private readonly struct IsEmptyValueConstraint<TItem>
		: IAsyncContextConstraint<IAsyncEnumerable<TItem>>
	{
		public async Task<ConstraintResult> IsMetBy(
			IAsyncEnumerable<TItem> actual,
			IEvaluationContext context,
			CancellationToken cancellationToken)
		{
			IAsyncEnumerable<TItem> materializedEnumerable =
				context.UseMaterializedAsyncEnumerable<TItem, IAsyncEnumerable<TItem>>(actual);
			await using IAsyncEnumerator<TItem> enumerator =
				materializedEnumerable.GetAsyncEnumerator(cancellationToken);
			if (await enumerator.MoveNextAsync())
			{
				List<TItem> items = new(11) { enumerator.Current };
				while (await enumerator.MoveNextAsync())
				{
					items.Add(enumerator.Current);
					if (items.Count == 11)
					{
						break;
					}
				}

				return new ConstraintResult.Failure(ToString(),
					$"found {Formatter.Format(items)}");
			}

			if (cancellationToken.IsCancellationRequested)
			{
				return new ConstraintResult.Failure(ToString(),
					"could not evaluate it, because it was already cancelled");
			}

			return new ConstraintResult.Success<IAsyncEnumerable<TItem>>(materializedEnumerable,
				ToString());
		}

		public override string ToString()
			=> "be empty";
	}

	private readonly struct IsNotEmptyConstraint<TItem>
		: IAsyncContextConstraint<IAsyncEnumerable<TItem>>
	{
		public async Task<ConstraintResult> IsMetBy(
			IAsyncEnumerable<TItem> actual,
			IEvaluationContext context,
			CancellationToken cancellationToken)
		{
			IAsyncEnumerable<TItem> materializedEnumerable =
				context.UseMaterializedAsyncEnumerable<TItem, IAsyncEnumerable<TItem>>(actual);
			await using IAsyncEnumerator<TItem> enumerator =
				materializedEnumerable.GetAsyncEnumerator(cancellationToken);
			if (await enumerator.MoveNextAsync())
			{
				return new ConstraintResult.Success<IAsyncEnumerable<TItem>>(materializedEnumerable,
					ToString());
			}

			return new ConstraintResult.Failure(ToString(), "it was");
		}

		public override string ToString()
			=> "not be empty";
	}
}
#endif
