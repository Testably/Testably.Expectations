using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<byte, IThat<byte>> BeGreaterThanOrEqualTo(
		this IThat<byte> source,
		byte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<byte>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<sbyte, IThat<sbyte>> BeGreaterThanOrEqualTo(
		this IThat<sbyte> source,
		sbyte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<sbyte>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<short, IThat<short>> BeGreaterThanOrEqualTo(
		this IThat<short> source,
		short? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<short>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ushort, IThat<ushort>> BeGreaterThanOrEqualTo(
		this IThat<ushort> source,
		ushort? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ushort>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<int, IThat<int>> BeGreaterThanOrEqualTo(
		this IThat<int> source,
		int? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<uint, IThat<uint>> BeGreaterThanOrEqualTo(
		this IThat<uint> source,
		uint? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<uint>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<long, IThat<long>> BeGreaterThanOrEqualTo(
		this IThat<long> source,
		long? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<long>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ulong, IThat<ulong>> BeGreaterThanOrEqualTo(
		this IThat<ulong> source,
		ulong? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<ulong>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<float, IThat<float>> BeGreaterThanOrEqualTo(
		this IThat<float> source,
		float? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<double, IThat<double>> BeGreaterThanOrEqualTo(
		this IThat<double> source,
		double? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<decimal, IThat<decimal>> BeGreaterThanOrEqualTo(
		this IThat<decimal> source,
		decimal? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<decimal>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<byte?, IThat<byte?>> BeGreaterThanOrEqualTo(
		this IThat<byte?> source,
		byte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<byte>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<sbyte?, IThat<sbyte?>> BeGreaterThanOrEqualTo(
		this IThat<sbyte?> source,
		sbyte? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<sbyte>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<short?, IThat<short?>> BeGreaterThanOrEqualTo(
		this IThat<short?> source,
		short? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<short>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ushort?, IThat<ushort?>> BeGreaterThanOrEqualTo(
		this IThat<ushort?> source,
		ushort? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ushort>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<int?, IThat<int?>> BeGreaterThanOrEqualTo(
		this IThat<int?> source,
		int? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<int>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<uint?, IThat<uint?>> BeGreaterThanOrEqualTo(
		this IThat<uint?> source,
		uint? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<uint>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<long?, IThat<long?>> BeGreaterThanOrEqualTo(
		this IThat<long?> source,
		long? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<long>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<ulong?, IThat<ulong?>> BeGreaterThanOrEqualTo(
		this IThat<ulong?> source,
		ulong? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<ulong>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> BeGreaterThanOrEqualTo(
		this IThat<float?> source,
		float? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> BeGreaterThanOrEqualTo(
		this IThat<double?> source,
		double? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is greater than or equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<decimal?, IThat<decimal?>> BeGreaterThanOrEqualTo(
		this IThat<decimal?> source,
		decimal? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<decimal>(
					expected,
					e => $"be greater than or equal to {Formatter.Format(e)}",
					(a, e) => a >= e,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeGreaterThanOrEqualTo), doNotPopulateThisValue),
			source);
}
