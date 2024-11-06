using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<byte, IThat<byte>> BeLessThan(
		this IThat<byte> source,
		byte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<byte, IThat<byte>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<byte>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<sbyte, IThat<sbyte>> BeLessThan(
		this IThat<sbyte> source,
		sbyte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<sbyte, IThat<sbyte>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<sbyte>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<short, IThat<short>> BeLessThan(
		this IThat<short> source,
		short? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<short> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<short, IThat<short>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<short>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<ushort, IThat<ushort>> BeLessThan(
		this IThat<ushort> source,
		ushort? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<ushort, IThat<ushort>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ushort>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<int, IThat<int>> BeLessThan(
		this IThat<int> source,
		int? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<int> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<int, IThat<int>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<uint, IThat<uint>> BeLessThan(
		this IThat<uint> source,
		uint? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<uint, IThat<uint>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<uint>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<long, IThat<long>> BeLessThan(
		this IThat<long> source,
		long? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<long> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<long, IThat<long>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<long>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<ulong, IThat<ulong>> BeLessThan(
		this IThat<ulong> source,
		ulong? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<ulong, IThat<ulong>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ulong>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<float, IThat<float>> BeLessThan(
		this IThat<float> source,
		float? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<float, IThat<float>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<double, IThat<double>> BeLessThan(
		this IThat<double> source,
		double? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<double, IThat<double>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NumberToleranceResult<decimal, IThat<decimal>> BeLessThan(
		this IThat<decimal> source,
		decimal? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NumberToleranceResult<decimal, IThat<decimal>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<decimal>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<byte, IThat<byte?>> BeLessThan(
		this IThat<byte?> source,
		byte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<byte> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<byte, IThat<byte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<byte>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<sbyte, IThat<sbyte?>> BeLessThan(
		this IThat<sbyte?> source,
		sbyte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<sbyte> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<sbyte, IThat<sbyte?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<sbyte>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<short, IThat<short?>> BeLessThan(
		this IThat<short?> source,
		short? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<short> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<short, IThat<short?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<short>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<ushort, IThat<ushort?>> BeLessThan(
		this IThat<ushort?> source,
		ushort? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<ushort> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<ushort, IThat<ushort?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ushort>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<int, IThat<int?>> BeLessThan(
		this IThat<int?> source,
		int? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<int> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<int, IThat<int?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<int>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<uint, IThat<uint?>> BeLessThan(
		this IThat<uint?> source,
		uint? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<uint> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<uint, IThat<uint?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<uint>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<long, IThat<long?>> BeLessThan(
		this IThat<long?> source,
		long? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<long> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<long, IThat<long?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<long>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<ulong, IThat<ulong?>> BeLessThan(
		this IThat<ulong?> source,
		ulong? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<ulong> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<ulong, IThat<ulong?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ulong>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<float, IThat<float?>> BeLessThan(
		this IThat<float?> source,
		float? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<float> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<float, IThat<float?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<double, IThat<double?>> BeLessThan(
		this IThat<double?> source,
		double? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<double> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<double, IThat<double?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is less than the <paramref name="expected" /> value.
	/// </summary>
	public static NullableNumberToleranceResult<decimal, IThat<decimal?>> BeLessThan(
		this IThat<decimal?> source,
		decimal? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		NumberTolerance<decimal> options = new(
			(a, e, t) => a < e - (t ?? 0));
		return new NullableNumberToleranceResult<decimal, IThat<decimal?>>(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<decimal>(
					expected,
					e => $"be less than {Formatter.Format(e)}{options}",
					(a, e) => options.IsWithinTolerance(a, e),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeLessThan), doNotPopulateThisValue),
			source,
			options);
	}
}
