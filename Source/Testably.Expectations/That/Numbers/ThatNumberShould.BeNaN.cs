using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is seen as not a number (<see cref="float.NaN" />).
	/// </summary>
	public static AndOrResult<float, IThat<float>> BeNaN(this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					float.NaN,
					_ => "be NaN",
					(a, _) => float.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as not a number (<see cref="double.NaN" />).
	/// </summary>
	public static AndOrResult<double, IThat<double>> BeNaN(this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					double.NaN,
					_ => "be NaN",
					(a, _) => double.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as not a number (not <see langword="null" /> and <see cref="float.NaN" />).
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> BeNaN(this IThat<float?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					float.NaN,
					_ => "be NaN",
					(a, _) => a != null && float.IsNaN(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as not a number (not <see langword="null" /> and <see cref="double.NaN" />).
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> BeNaN(this IThat<double?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					double.NaN,
					_ => "be NaN",
					(a, _) => a != null && double.IsNaN(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as not a number (not <see cref="float.NaN" />).
	/// </summary>
	public static AndOrResult<float, IThat<float>> NotBeNaN(this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					float.NaN,
					_ => "not be NaN",
					(a, _) => !float.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as not a number (not <see cref="double.NaN" />).
	/// </summary>
	public static AndOrResult<double, IThat<double>> NotBeNaN(this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					double.NaN,
					_ => "not be NaN",
					(a, _) => !double.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as not a number (<see langword="null" /> or not not <see cref="float.NaN" />
	///     ).
	/// </summary>
	public static AndOrResult<float?, IThat<float?>> NotBeNaN(this IThat<float?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<float>(
					float.NaN,
					_ => "not be NaN",
					(a, _) => a == null || !float.IsNaN(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeNaN)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as not a number (<see langword="null" /> or not <see cref="double.NaN" />).
	/// </summary>
	public static AndOrResult<double?, IThat<double?>> NotBeNaN(this IThat<double?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new NullableGenericConstraint<double>(
					double.NaN,
					_ => "not be NaN",
					(a, _) => a == null || !double.IsNaN(a.Value),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeNaN)),
			source);
}
