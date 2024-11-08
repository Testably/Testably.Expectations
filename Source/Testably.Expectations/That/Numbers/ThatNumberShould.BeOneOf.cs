using System;
using System.Linq;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> BeOneOf(
		this IThat<byte> source,
		params byte?[] expected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<byte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> BeOneOf(
		this IThat<sbyte> source,
		params sbyte?[] expected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<sbyte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> BeOneOf(
		this IThat<short> source,
		params short?[] expected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<short>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> BeOneOf(
		this IThat<ushort> source,
		params ushort?[] expected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<ushort>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> BeOneOf(
		this IThat<int> source,
		params int?[] expected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<int>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> BeOneOf(
		this IThat<uint> source,
		params uint?[] expected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<uint>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> BeOneOf(
		this IThat<long> source,
		params long?[] expected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<long>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> BeOneOf(
		this IThat<ulong> source,
		params ulong?[] expected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<ulong>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> BeOneOf(
		this IThat<float> source,
		params float?[] expected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<float>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> BeOneOf(
		this IThat<double> source,
		params double?[] expected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<double>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> BeOneOf(
		this IThat<decimal> source,
		params decimal?[] expected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<decimal>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> BeOneOf(
		this IThat<byte?> source,
		params byte?[] expected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<byte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> BeOneOf(
		this IThat<sbyte?> source,
		params sbyte?[] expected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<sbyte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> BeOneOf(
		this IThat<short?> source,
		params short?[] expected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<short>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> BeOneOf(
		this IThat<ushort?> source,
		params ushort?[] expected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<ushort>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> BeOneOf(
		this IThat<int?> source,
		params int?[] expected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<int>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> BeOneOf(
		this IThat<uint?> source,
		params uint?[] expected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<uint>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> BeOneOf(
		this IThat<long?> source,
		params long?[] expected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<long>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> BeOneOf(
		this IThat<ulong?> source,
		params ulong?[] expected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<ulong>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> BeOneOf(
		this IThat<float?> source,
		params float?[] expected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<float>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> BeOneOf(
		this IThat<double?> source,
		params double?[] expected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<double>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> BeOneOf(
		this IThat<decimal?> source,
		params decimal?[] expected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<decimal>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> BeOneOf(
		this IThat<byte> source,
		params byte[] expected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<byte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> BeOneOf(
		this IThat<sbyte> source,
		params sbyte[] expected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<sbyte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> BeOneOf(
		this IThat<short> source,
		params short[] expected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<short>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> BeOneOf(
		this IThat<ushort> source,
		params ushort[] expected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<ushort>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> BeOneOf(
		this IThat<int> source,
		params int[] expected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<int>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> BeOneOf(
		this IThat<uint> source,
		params uint[] expected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<uint>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> BeOneOf(
		this IThat<long> source,
		params long[] expected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<long>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> BeOneOf(
		this IThat<ulong> source,
		params ulong[] expected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<ulong>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> BeOneOf(
		this IThat<float> source,
		params float[] expected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<float>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> BeOneOf(
		this IThat<double> source,
		params double[] expected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<double>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> BeOneOf(
		this IThat<decimal> source,
		params decimal[] expected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<decimal>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> BeOneOf(
		this IThat<byte?> source,
		params byte[] expected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<byte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> BeOneOf(
		this IThat<sbyte?> source,
		params sbyte[] expected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<sbyte>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> BeOneOf(
		this IThat<short?> source,
		params short[] expected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<short>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> BeOneOf(
		this IThat<ushort?> source,
		params ushort[] expected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<ushort>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> BeOneOf(
		this IThat<int?> source,
		params int[] expected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<int>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> BeOneOf(
		this IThat<uint?> source,
		params uint[] expected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<uint>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> BeOneOf(
		this IThat<long?> source,
		params long[] expected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<long>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> BeOneOf(
		this IThat<ulong?> source,
		params ulong[] expected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<ulong>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> BeOneOf(
		this IThat<float?> source,
		params float[] expected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<float>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> BeOneOf(
		this IThat<double?> source,
		params double[] expected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<double>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is one of the <paramref name="expected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> BeOneOf(
		this IThat<decimal?> source,
		params decimal[] expected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<decimal>(
					expected,
					e => $"be one of {Formatter.Format(e)}{options}",
					(a, e) => e.Any(v => options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> NotBeOneOf(
		this IThat<byte> source,
		params byte?[] unexpected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<byte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> NotBeOneOf(
		this IThat<sbyte> source,
		params sbyte?[] unexpected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<sbyte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> NotBeOneOf(
		this IThat<short> source,
		params short?[] unexpected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<short>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> NotBeOneOf(
		this IThat<ushort> source,
		params ushort?[] unexpected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<ushort>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> NotBeOneOf(
		this IThat<int> source,
		params int?[] unexpected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<int>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> NotBeOneOf(
		this IThat<uint> source,
		params uint?[] unexpected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<uint>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> NotBeOneOf(
		this IThat<long> source,
		params long?[] unexpected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<long>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> NotBeOneOf(
		this IThat<ulong> source,
		params ulong?[] unexpected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<ulong>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> NotBeOneOf(
		this IThat<float> source,
		params float?[] unexpected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<float>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> NotBeOneOf(
		this IThat<double> source,
		params double?[] unexpected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<double>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> NotBeOneOf(
		this IThat<decimal> source,
		params decimal?[] unexpected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint<decimal>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> NotBeOneOf(
		this IThat<byte?> source,
		params byte?[] unexpected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<byte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> NotBeOneOf(
		this IThat<sbyte?> source,
		params sbyte?[] unexpected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<sbyte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> NotBeOneOf(
		this IThat<short?> source,
		params short?[] unexpected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<short>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> NotBeOneOf(
		this IThat<ushort?> source,
		params ushort?[] unexpected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<ushort>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> NotBeOneOf(
		this IThat<int?> source,
		params int?[] unexpected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<int>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> NotBeOneOf(
		this IThat<uint?> source,
		params uint?[] unexpected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<uint>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> NotBeOneOf(
		this IThat<long?> source,
		params long?[] unexpected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<long>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> NotBeOneOf(
		this IThat<ulong?> source,
		params ulong?[] unexpected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<ulong>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> NotBeOneOf(
		this IThat<float?> source,
		params float?[] unexpected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<float>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> NotBeOneOf(
		this IThat<double?> source,
		params double?[] unexpected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<double>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> NotBeOneOf(
		this IThat<decimal?> source,
		params decimal?[] unexpected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint<decimal>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> NotBeOneOf(
		this IThat<byte> source,
		params byte[] unexpected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<byte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> NotBeOneOf(
		this IThat<sbyte> source,
		params sbyte[] unexpected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<sbyte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> NotBeOneOf(
		this IThat<short> source,
		params short[] unexpected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<short>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> NotBeOneOf(
		this IThat<ushort> source,
		params ushort[] unexpected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<ushort>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> NotBeOneOf(
		this IThat<int> source,
		params int[] unexpected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<int>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> NotBeOneOf(
		this IThat<uint> source,
		params uint[] unexpected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<uint>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> NotBeOneOf(
		this IThat<long> source,
		params long[] unexpected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<long>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> NotBeOneOf(
		this IThat<ulong> source,
		params ulong[] unexpected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<ulong>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> NotBeOneOf(
		this IThat<float> source,
		params float[] unexpected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<float>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> NotBeOneOf(
		this IThat<double> source,
		params double[] unexpected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<double>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> NotBeOneOf(
		this IThat<decimal> source,
		params decimal[] unexpected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericArrayConstraint2<decimal>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> NotBeOneOf(
		this IThat<byte?> source,
		params byte[] unexpected)
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<byte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> NotBeOneOf(
		this IThat<sbyte?> source,
		params sbyte[] unexpected)
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<sbyte>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> NotBeOneOf(
		this IThat<short?> source,
		params short[] unexpected)
	{
		NumberTolerance<short> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<short>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> NotBeOneOf(
		this IThat<ushort?> source,
		params ushort[] unexpected)
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<ushort>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> NotBeOneOf(
		this IThat<int?> source,
		params int[] unexpected)
	{
		NumberTolerance<int> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<int>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> NotBeOneOf(
		this IThat<uint?> source,
		params uint[] unexpected)
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<uint>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> NotBeOneOf(
		this IThat<long?> source,
		params long[] unexpected)
	{
		NumberTolerance<long> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<long>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> NotBeOneOf(
		this IThat<ulong?> source,
		params ulong[] unexpected)
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => (a > e ? a - e : e - a) <= (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<ulong>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> NotBeOneOf(
		this IThat<float?> source,
		params float[] unexpected)
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<float>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> NotBeOneOf(
		this IThat<double?> source,
		params double[] unexpected)
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a.Equals(e) || Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<double>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is not one of the <paramref name="unexpected" /> values.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> NotBeOneOf(
		this IThat<decimal?> source,
		params decimal[] unexpected)
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => Math.Abs(a - e) <= (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericArrayConstraint2<decimal>(
					unexpected,
					u => $"not be one of {Formatter.Format(u)}{options}",
					(a, u) => u.All(v => !options.IsWithinTolerance(a, v)),
					(a, _) => $"found {Formatter.Format(a)}")),
			source,
			options);
	}
	
	
	
	
	
	
	
	
}
