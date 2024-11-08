using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> Be(
		this IThat<byte> source,
		byte? expected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<byte>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> Be(
		this IThat<sbyte> source,
		sbyte? expected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<sbyte>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> Be(
		this IThat<short> source,
		short? expected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<short>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> Be(
		this IThat<ushort> source,
		ushort? expected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ushort>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> Be(
		this IThat<int> source,
		int? expected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> Be(
		this IThat<uint> source,
		uint? expected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<uint>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> Be(
		this IThat<long> source,
		long? expected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<long>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> Be(
		this IThat<ulong> source,
		ulong? expected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ulong>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> Be(
		this IThat<float> source,
		float? expected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> Be(
		this IThat<double> source,
		double? expected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> Be(
		this IThat<decimal> source,
		decimal? expected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<decimal>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> Be(
		this IThat<byte?> source,
		byte? expected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<byte>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> Be(
		this IThat<sbyte?> source,
		sbyte? expected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<sbyte>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> Be(
		this IThat<short?> source,
		short? expected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<short>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> Be(
		this IThat<ushort?> source,
		ushort? expected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ushort>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> Be(
		this IThat<int?> source,
		int? expected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<int>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> Be(
		this IThat<uint?> source,
		uint? expected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<uint>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> Be(
		this IThat<long?> source,
		long? expected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<long>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> Be(
		this IThat<ulong?> source,
		ulong? expected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ulong>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> Be(
		this IThat<float?> source,
		float? expected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> Be(
		this IThat<double?> source,
		double? expected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> Be(
		this IThat<decimal?> source,
		decimal? expected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<decimal>(
					expected,
					e => $"be {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> NotBe(
		this IThat<byte> source,
		byte? unexpected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<byte>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> NotBe(
		this IThat<sbyte> source,
		sbyte? unexpected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<sbyte>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> NotBe(
		this IThat<short> source,
		short? unexpected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<short>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> NotBe(
		this IThat<ushort> source,
		ushort? unexpected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ushort>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> NotBe(
		this IThat<int> source,
		int? unexpected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> NotBe(
		this IThat<uint> source,
		uint? unexpected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<uint>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> NotBe(
		this IThat<long> source,
		long? unexpected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<long>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> NotBe(
		this IThat<ulong> source,
		ulong? unexpected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ulong>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> NotBe(
		this IThat<float> source,
		float? unexpected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> NotBe(
		this IThat<double> source,
		double? unexpected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> NotBe(
		this IThat<decimal> source,
		decimal? unexpected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<decimal>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> NotBe(
		this IThat<byte?> source,
		byte? unexpected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<byte>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> NotBe(
		this IThat<sbyte?> source,
		sbyte? unexpected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<sbyte>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> NotBe(
		this IThat<short?> source,
		short? unexpected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<short>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> NotBe(
		this IThat<ushort?> source,
		ushort? unexpected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ushort>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> NotBe(
		this IThat<int?> source,
		int? unexpected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<int>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> NotBe(
		this IThat<uint?> source,
		uint? unexpected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<uint>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> NotBe(
		this IThat<long?> source,
		long? unexpected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<long>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> NotBe(
		this IThat<ulong?> source,
		ulong? unexpected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ulong>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> NotBe(
		this IThat<float?> source,
		float? unexpected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> NotBe(
		this IThat<double?> source,
		double? unexpected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> NotBe(
		this IThat<decimal?> source,
		decimal? unexpected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<decimal>(
					unexpected,
					u => $"not be {Formatter.Format(u)}{options}",
					(a, u) => !options.IsWithinTolerance(a, u),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}
}
