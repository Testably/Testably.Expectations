using System;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Options;

/// <summary>
///     Tolerance for number comparisons.
/// </summary>
public class NumberTolerance<TNumber>
	where TNumber : struct, IComparable<TNumber>
{
	/// <summary>
	///     The tolerance to apply on the number comparisons.
	/// </summary>
	public TNumber? Tolerance { get; private set; }

	/// <summary>
	///     Sets the tolerance to apply on the time comparisons.
	/// </summary>
	public NumberTolerance<TNumber> SetTolerance(TNumber tolerance)
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

	internal bool IsWithinTolerance(TNumber actual, TNumber? expected)
	{
		if (expected == null)
		{
			return false;
		}

		if (actual is int actualInt &&
		    expected is int expectedInt &&
		    Tolerance is int toleranceInt)
		{
			return Math.Abs(actualInt - expectedInt) <= toleranceInt;
		}

		if (actual is uint actualUint &&
		    expected is uint expectedUint &&
		    Tolerance is uint toleranceUint)
		{
			uint difference = actualUint > expectedUint
				? actualUint - expectedUint
				: expectedUint - actualUint;
			return difference <= toleranceUint;
		}

		return expected.Value.CompareTo(actual) == 0;
	}
}
