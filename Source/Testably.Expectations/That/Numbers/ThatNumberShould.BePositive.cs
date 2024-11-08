using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<sbyte, IThat<sbyte>> BePositive(
		this IThat<sbyte> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<sbyte>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<short, IThat<short>> BePositive(
		this IThat<short> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<short>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<int, IThat<int>> BePositive(
		this IThat<int> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<long, IThat<long>> BePositive(
		this IThat<long> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<long>(
					0L,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<float, IThat<float>> BePositive(
		this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					0.0F,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<double, IThat<double>> BePositive(
		this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					0.0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<decimal, IThat<decimal>> BePositive(
		this IThat<decimal> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<decimal>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<sbyte?, IThat<sbyte?>> BePositive(
		this IThat<sbyte?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<sbyte>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<short?, IThat<short?>> BePositive(
		this IThat<short?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<short>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<int?, IThat<int?>> BePositive(
		this IThat<int?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<int>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<long?, IThat<long?>> BePositive(
		this IThat<long?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<long>(
					0L,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> BePositive(
		this IThat<float?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					0.0F,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> BePositive(
		this IThat<double?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					0.0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<decimal?, IThat<decimal?>> BePositive(
		this IThat<decimal?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<decimal>(
					0,
					_ => "be positive",
					(a, e) => a > e,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);
}
