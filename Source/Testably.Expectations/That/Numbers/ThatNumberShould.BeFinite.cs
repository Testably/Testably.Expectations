using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNumberShould
{
	/// <summary>
	///     Verifies that the subject is seen as finite (neither <see cref="float.IsInfinity" /> nor <see cref="float.IsNaN"/>).
	/// </summary>
	public static AndOrResult<float, IThat<float>> BeFinite(
		this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					float.PositiveInfinity,
					"be finite",
					(a, _) => !float.IsInfinity(a) && !float.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeFinite)),
			source);

	/// <summary>
	///     Verifies that the subject is seen as finite (neither <see cref="double.IsInfinity" /> nor <see cref="double.IsNaN"/>).
	/// </summary>
	public static AndOrResult<double, IThat<double>> BeFinite(
		this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					double.PositiveInfinity,
					"be finite",
					(a, _) => !double.IsInfinity(a) && !double.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeFinite)),
			source);
	
	/// <summary>
	///     Verifies that the subject is not seen as finite (either <see cref="float.IsInfinity" /> or <see cref="float.IsNaN"/>).
	/// </summary>
	public static AndOrResult<float, IThat<float>> NotBeFinite(
		this IThat<float> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<float>(
					float.PositiveInfinity,
					"not be finite",
					(a, _) => float.IsInfinity(a) || float.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeFinite)),
			source);

	/// <summary>
	///     Verifies that the subject is not seen as finite (either <see cref="double.IsInfinity" /> or <see cref="double.IsNaN"/>).
	/// </summary>
	public static AndOrResult<double, IThat<double>> NotBeFinite(
		this IThat<double> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<double>(
					double.PositiveInfinity,
					"not be finite",
					(a, _) => double.IsInfinity(a) || double.IsNaN(a),
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(NotBeFinite)),
			source);
}
