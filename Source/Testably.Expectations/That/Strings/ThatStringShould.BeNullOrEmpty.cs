using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" /> or empty.
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeNullOrEmpty(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<string>(
					"",
					_ => "be null or empty",
					(a, _) => string.IsNullOrEmpty(a),
					(a, _)
						=> $"found {Formatter.Format(a.DisplayWhitespace().TruncateWithEllipsis(100))}")),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" /> or empty.
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeNullOrEmpty(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<string>(
					"",
					_ => "not be null or empty",
					(a, _) => !string.IsNullOrEmpty(a),
					(a, _) => $"found {Formatter.Format(a)}")),
			source);
}
