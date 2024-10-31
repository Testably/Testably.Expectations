using System.Diagnostics.CodeAnalysis;
using Testably.Expectations.That.Collections;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

public abstract partial class CollectionQuantifier
{
	/// <summary>
	///     Matches all items in the collection.
	/// </summary>
	public static CollectionQuantifier All => new AllQuantifier();

	private class AllQuantifier : CollectionQuantifier
	{
		/// <inheritdoc />
		protected override bool ContinueEvaluation(
			int matchingCount, int notMatchingCount,
			int? totalCount,
			[NotNullWhen(false)] out CollectionEvaluatorResult? result)
		{
			if (notMatchingCount > 0)
			{
				result = new(false, totalCount.HasValue
					? $"not all of {totalCount}"
					: "not all");
				return false;
			}

			if (matchingCount == totalCount)
			{
				result = new(true, "");
				return false;
			}

			result = null;
			return true;
		}

		/// <inheritdoc />
		public override string ToString() => "all items";
	}
}
