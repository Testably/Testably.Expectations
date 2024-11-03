using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> Be(
		this IThat<short> source,
		short? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<short> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<short>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> Be(
		this IThat<ushort> source,
		ushort? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<ushort>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> Be(
		this IThat<int> source,
		int? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<int> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<int>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> Be(
		this IThat<uint> source,
		uint? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<uint>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> Be(
		this IThat<long> source,
		long? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<long> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<long>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> Be(
		this IThat<ulong> source,
		ulong? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<ulong>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> Be(
		this IThat<byte> source,
		byte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<byte>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> Be(
		this IThat<sbyte> source,
		sbyte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<sbyte>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> Be(
		this IThat<decimal> source,
		decimal? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<decimal>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> Be(
		this IThat<float> source,
		float? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<float>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> Be(
		this IThat<double> source,
		double? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new IsValueWithToleranceConstraint<double>(expected, options))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<TNumber?, IThat<TNumber?>> Be<TNumber>(
		this IThat<TNumber?> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint<TNumber>(expected))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<TNumber, IThat<TNumber>> NotBe<TNumber>(
		this IThat<TNumber> source,
		TNumber? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TNumber : struct, IComparable<TNumber>
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotValueConstraint<TNumber>(expected))
				.AppendMethodStatement(nameof(NotBe), doNotPopulateThisValue),
			source);

	private readonly struct IsValueConstraint<TNumber>(TNumber? expected)
		: IValueConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (expected?.CompareTo(actual) == 0)
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"be {Formatter.Format(expected)}";
	}

	private readonly struct IsValueWithToleranceConstraint<TNumber>(
		TNumber? expected,
		NumberTolerance<TNumber> options)
		: IValueConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (options.IsWithinTolerance(actual, expected))
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"be {Formatter.Format(expected)}{options}";
	}

	private readonly struct IsNotValueConstraint<TNumber>(TNumber? expected)
		: IValueConstraint<TNumber>
		where TNumber : struct, IComparable<TNumber>
	{
		public ConstraintResult IsMetBy(TNumber actual)
		{
			if (expected?.CompareTo(actual) != 0)
			{
				return new ConstraintResult.Success<TNumber>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"not be {Formatter.Format(expected)}";
	}
}
