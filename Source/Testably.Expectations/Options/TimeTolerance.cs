using System;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Options;

/// <summary>
///     Tolerance for time comparisons.
/// </summary>
public class TimeTolerance
{
	/// <summary>
	///     The tolerance to apply on the time comparisons.
	/// </summary>
	public TimeSpan? Tolerance { get; private set; }

	/// <summary>
	///     Sets the tolerance to apply on the time comparisons.
	/// </summary>
	public TimeTolerance SetTolerance(TimeSpan tolerance)
	{
		Tolerance = tolerance;
		return this;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		if (Tolerance == null)
		{
			return "";
		}

		const char plusMinus = '\u00b1';
		return $" {plusMinus} {Formatter.Format(Tolerance.Value)}";
	}

	internal bool IsWithinTolerance(TimeSpan difference)
	{
		if (Tolerance == null)
		{
			return difference == TimeSpan.Zero;
		}

		return difference <= Tolerance.Value && difference >= Tolerance.Value.Negate();
	}
}
