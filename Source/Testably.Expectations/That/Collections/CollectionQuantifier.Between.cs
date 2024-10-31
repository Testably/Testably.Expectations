using System.Diagnostics.CodeAnalysis;
using Testably.Expectations.That.Collections;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

public abstract partial class CollectionQuantifier
{
	/// <summary>
	///     Matches between <paramref name="minimum" /> and <paramref name="maximum" /> items.
	/// </summary>
	public static CollectionQuantifier Between(int minimum, int maximum)
		=> new BetweenQuantifier(minimum, maximum);

	private class BetweenQuantifier(int minimum, int maximum) : CollectionQuantifier
	{
		/// <inheritdoc />
		protected override bool ContinueEvaluation(
			int matchingCount, int notMatchingCount,
			int? totalCount,
			[NotNullWhen(false)] out CollectionEvaluatorResult? result)
		{
			if (matchingCount > maximum)
			{
				result = new(false, totalCount.HasValue
					? $"at least {matchingCount} of {totalCount}"
					: $"at least {matchingCount}");
				return false;
			}

			if (totalCount != null && matchingCount + notMatchingCount == totalCount)
			{
				if (matchingCount >= minimum)
				{
					result = new(true, "");
					return false;
				}

				result = new(false, $"only {matchingCount}");
				return false;
			}

			result = null;
			return true;
		}

		/// <inheritdoc />
		public override string ToString() => $"between {minimum} and {maximum} items";
	}
}
