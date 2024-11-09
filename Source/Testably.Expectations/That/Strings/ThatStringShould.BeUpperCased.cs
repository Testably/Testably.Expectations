using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that all cased characters in the subject are upper-case.<br />
	///     That is, that the string could be the result of a call to <see cref="string.ToUpperInvariant()" />,
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeUpperCased(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint(
					"",
					_ => "be upper-cased",
					(a, _) => a != null && a == a.ToUpperInvariant(),
					(a, _) => $"found {Formatter.Format(a, FormattingOptions.SingleLine)}")),
			source);

	/// <summary>
	///     Verifies that of all cased characters in the subject some are lower-case.<br />
	///     That is, that the string could not be the result of a call to <see cref="string.ToUpperInvariant()" />,
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeUpperCased(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint(
					"",
					_ => "not be upper-cased",
					(a, _) => a == null || a != a.ToUpperInvariant(),
					(a, _) => $"found {Formatter.Format(a, FormattingOptions.SingleLine)}")),
			source);
}
