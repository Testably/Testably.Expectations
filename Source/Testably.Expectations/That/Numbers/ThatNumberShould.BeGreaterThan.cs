using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<byte, IThat<byte>> BeGreaterThan(
		this IThat<byte> source,
		byte? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<byte>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<sbyte, IThat<sbyte>> BeGreaterThan(
		this IThat<sbyte> source,
		sbyte? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<sbyte>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<short, IThat<short>> BeGreaterThan(
		this IThat<short> source,
		short? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<short>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ushort, IThat<ushort>> BeGreaterThan(
		this IThat<ushort> source,
		ushort? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ushort>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<int, IThat<int>> BeGreaterThan(
		this IThat<int> source,
		int? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<uint, IThat<uint>> BeGreaterThan(
		this IThat<uint> source,
		uint? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<uint>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<long, IThat<long>> BeGreaterThan(
		this IThat<long> source,
		long? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<long>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ulong, IThat<ulong>> BeGreaterThan(
		this IThat<ulong> source,
		ulong? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ulong>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<float, IThat<float>> BeGreaterThan(
		this IThat<float> source,
		float? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<double, IThat<double>> BeGreaterThan(
		this IThat<double> source,
		double? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<decimal, IThat<decimal>> BeGreaterThan(
		this IThat<decimal> source,
		decimal? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<decimal>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<byte?, IThat<byte?>> BeGreaterThan(
		this IThat<byte?> source,
		byte? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<byte>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<sbyte?, IThat<sbyte?>> BeGreaterThan(
		this IThat<sbyte?> source,
		sbyte? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<sbyte>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<short?, IThat<short?>> BeGreaterThan(
		this IThat<short?> source,
		short? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<short>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ushort?, IThat<ushort?>> BeGreaterThan(
		this IThat<ushort?> source,
		ushort? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ushort>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<int?, IThat<int?>> BeGreaterThan(
		this IThat<int?> source,
		int? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<int>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<uint?, IThat<uint?>> BeGreaterThan(
		this IThat<uint?> source,
		uint? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<uint>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<long?, IThat<long?>> BeGreaterThan(
		this IThat<long?> source,
		long? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<long>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ulong?, IThat<ulong?>> BeGreaterThan(
		this IThat<ulong?> source,
		ulong? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ulong>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> BeGreaterThan(
		this IThat<float?> source,
		float? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> BeGreaterThan(
		this IThat<double?> source,
		double? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is greater than the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<decimal?, IThat<decimal?>> BeGreaterThan(
		this IThat<decimal?> source,
		decimal? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<decimal>(
					expected,
					e => $"be greater than {Formatter.Format(e)}",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);
}
