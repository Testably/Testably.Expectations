using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on numeric values.
/// </summary>
public static partial class ThatNumberExtensions
{
	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TNumber, That<TNumber>> Is<TNumber>(
		this That<TNumber> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsConstraint<TNumber>(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TNumber?, That<TNumber?>> Is<TNumber>(
		this That<TNumber?> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsConstraint<TNumber>(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is seen as not a number (<see cref="float.NaN" />).
	/// </summary>
	public static AndOrExpectationResult<float, That<float>> IsNaN(this That<float> source)
		=> new(source.ExpectationBuilder.Add(new IsNaNConstraint<float>(float.IsNaN),
				b => b.AppendMethod(nameof(IsNaN))),
			source);

	/// <summary>
	///     Verifies that the actual value is seen as not a number (<see cref="double.NaN" />).
	/// </summary>
	public static AndOrExpectationResult<double, That<double>> IsNaN(this That<double> source)
		=> new(source.ExpectationBuilder.Add(new IsNaNConstraint<double>(double.IsNaN),
				b => b.AppendMethod(nameof(IsNaN))),
			source);

	/// <summary>
	///     Verifies that the actual value is not equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TNumber, That<TNumber>> IsNot<TNumber>(
		this That<TNumber> source,
		TNumber expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder.Add(new IsNotConstraint<TNumber>(expected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);
}
