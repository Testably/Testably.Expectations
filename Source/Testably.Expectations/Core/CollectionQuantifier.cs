using System.Diagnostics.CodeAnalysis;

namespace Testably.Expectations.Core;

/// <summary>
///     Quantifier for collections.
/// </summary>
public abstract class CollectionQuantifier
{
	/// <summary>
	///     Matches all items in the collection.
	/// </summary>
	public static CollectionQuantifier All => new AllQuantifier();

	/// <summary>
	///     Matches no items in the collection.
	/// </summary>
	public static CollectionQuantifier None => new NoneQuantifier();

	/// <summary>
	///     Matches at least <paramref name="minimum" /> items.
	/// </summary>
	public static CollectionQuantifier AtLeast(int minimum) => new AtLeastQuantifier(minimum);

	/// <summary>
	///     Matches at most <paramref name="maximum" /> items.
	/// </summary>
	public static CollectionQuantifier AtMost(int maximum) => new AtMostQuantifier(maximum);

	/// <summary>
	///     Matches between <paramref name="minimum" /> and <paramref name="maximum" /> items.
	/// </summary>
	public static CollectionQuantifier Between(int minimum, int maximum)
		=> new BetweenQuantifier(minimum, maximum);

	/// <summary>
	///     Checks if the number of <paramref name="actual" /> items of the <paramref name="total" /> items match the
	///     condition.
	///     <para />
	///     If not, the <paramref name="error" /> contains the error message.
	/// </summary>
	public abstract bool CheckCondition(int total, int actual,
		[NotNullWhen(false)] out string? error);

	private class NoneQuantifier : CollectionQuantifier
	{
		/// <inheritdoc />
		public override bool CheckCondition(int total, int actual,
			[NotNullWhen(false)] out string? error)
		{
			if (actual == 0)
			{
				error = null;
				return true;
			}

			error = $"{actual}";
			return false;
		}

		/// <inheritdoc />
		public override string ToString() => "no items";
	}

	private class AllQuantifier : CollectionQuantifier
	{
		/// <inheritdoc />
		public override bool CheckCondition(int total, int actual,
			[NotNullWhen(false)] out string? error)
		{
			if (actual == total)
			{
				error = null;
				return true;
			}

			error = $"only {actual} of {total}";
			return false;
		}

		/// <inheritdoc />
		public override string ToString() => "all items";
	}

	private class AtLeastQuantifier(int minimum) : CollectionQuantifier
	{
		/// <inheritdoc />
		public override bool CheckCondition(int total, int actual,
			[NotNullWhen(false)] out string? error)
		{
			if (actual >= minimum)
			{
				error = null;
				return true;
			}

			error = $"only {actual} of {total}";
			return false;
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"at least {minimum} {(minimum == 1 ? "item" : "items")}";
	}

	private class BetweenQuantifier(int minimum, int maximum) : CollectionQuantifier
	{
		/// <inheritdoc />
		public override bool CheckCondition(int total, int actual,
			[NotNullWhen(false)] out string? error)
		{
			if (actual >= minimum && actual <= maximum)
			{
				error = null;
				return true;
			}

			if (actual >= minimum)
			{
				error = $"{actual}";
				return false;
			}

			error = $"only {actual}";
			return false;
		}

		/// <inheritdoc />
		public override string ToString() => $"between {minimum} and {maximum} items";
	}

	private class AtMostQuantifier(int maximum) : CollectionQuantifier
	{
		/// <inheritdoc />
		public override bool CheckCondition(int total, int actual,
			[NotNullWhen(false)] out string? error)
		{
			if (actual <= maximum)
			{
				error = null;
				return true;
			}

			error = $"{actual} of {total}";
			return false;
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"at most {maximum} {(maximum == 1 ? "item" : "items")}";
	}
}
