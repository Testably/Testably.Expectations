using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />, empty or consists only of white-space characters.
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeNullOrWhiteSpace(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint(
					"",
					_ => "be null or white-space",
					(a, _) => string.IsNullOrWhiteSpace(a),
					(a, _)
						=> $"found {Formatter.Format(a, FormattingOptions.SingleLine)}")),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />, empty or consists only of white-space characters.
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeNullOrWhiteSpace(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint(
					"",
					_ => "not be null or white-space",
					(a, _) => !string.IsNullOrWhiteSpace(a),
					(a, _)
						=> $"found {Formatter.Format(a, FormattingOptions.SingleLine)}")),
			source);
}
