using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is seen as infinite (<see cref="float.IsInfinity" />).
	/// </summary>
	public static AndOrResult<float, IThat<float>> BeInfinite(this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					float.PositiveInfinity,
					"be infinite",
					(a, _) => float.IsInfinity(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as infinite (<see cref="double.IsInfinity" />).
	/// </summary>
	public static AndOrResult<double, IThat<double>> BeInfinite(
		this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					double.PositiveInfinity,
					"be infinite",
					(a, _) => double.IsInfinity(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as infinite (not <see langword="null" /> and <see cref="float.IsInfinity" />).
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> BeInfinite(this IThat<float?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float?>(
					float.PositiveInfinity,
					"be infinite",
					(a, _) => a != null && float.IsInfinity(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as infinite (not <see langword="null" /> and <see cref="double.IsInfinity" />).
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> BeInfinite(
		this IThat<double?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double?>(
					double.PositiveInfinity,
					"be infinite",
					(a, _) => a != null && double.IsInfinity(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as infinite (not <see cref="float.IsInfinity" />).
	/// </summary>
	public static AndOrResult<float, IThat<float>> NotBeInfinite(
		this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					float.PositiveInfinity,
					"not be infinite",
					(a, _) => !float.IsInfinity(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as infinite (not <see cref="double.IsInfinity" />).
	/// </summary>
	public static AndOrResult<double, IThat<double>> NotBeInfinite(
		this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					double.PositiveInfinity,
					"not be infinite",
					(a, _) => !double.IsInfinity(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as infinite (<see langword="null" /> or not <see cref="float.IsInfinity" />).
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> NotBeInfinite(
		this IThat<float?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float?>(
					float.PositiveInfinity,
					"not be infinite",
					(a, _) => a == null || !float.IsInfinity(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeInfinite)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as infinite (<see langword="null" /> or not <see cref="double.IsInfinity" />
	///     ).
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> NotBeInfinite(
		this IThat<double?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double?>(
					double.PositiveInfinity,
					"not be infinite",
					(a, _) => a == null || !double.IsInfinity(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeInfinite)),
			source);
}
