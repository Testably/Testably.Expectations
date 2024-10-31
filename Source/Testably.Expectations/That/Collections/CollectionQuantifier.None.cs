using System.Diagnostics.CodeAnalysis;
using Testably.Expectations.That.Collections;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

public abstract partial class CollectionQuantifier
{
	/// <summary>
	///     Matches no items in the collection.
	/// </summary>
	public static CollectionQuantifier None => new NoneQuantifier();

	private class NoneQuantifier : CollectionQuantifier
	{
		/// <inheritdoc />
		protected override bool ContinueEvaluation(
			int matchingCount, int notMatchingCount,
			int? totalCount,
			[NotNullWhen(false)] out CollectionEvaluatorResult? result)
		{
			if (matchingCount > 0)
			{
				result = new(false, "at least one");
				return false;
			}

			if (notMatchingCount == totalCount)
			{
				result = new(true, "");
				return false;
			}

			result = null;
			return true;
		}

		/// <inheritdoc />
		public override string ToString() => "no items";
	}
}
