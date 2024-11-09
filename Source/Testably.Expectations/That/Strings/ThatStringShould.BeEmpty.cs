using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is empty.
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeEmpty(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint(
					"",
					_ => "be empty",
					(a, _) => a == "",
					(a, _)
						=> $"found {Formatter.Format(a, FormattingOptions.SingleLine)}")),
			source);

	/// <summary>
	///     Verifies that the subject is not empty.
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeEmpty(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint(
					"",
					_ => "not be empty",
					(a, _) => a != "",
					(_, _) => "it was")),
			source);
}
