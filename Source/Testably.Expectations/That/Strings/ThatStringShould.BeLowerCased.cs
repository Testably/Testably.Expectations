using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that all cased characters in the subject are lower-case.<br />
	///     That is, that the string could be the result of a call to <see cref="string.ToLowerInvariant()" />,
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeLowerCased(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<string>(
					"",
					_ => "be lower-cased",
					(a, _) => a != null && a == a.ToLowerInvariant(),
					(a, _)
						=> $"found {Formatter.Format(a.DisplayWhitespace().TruncateWithEllipsis(100))}")),
			source);

	/// <summary>
	///     Verifies that of all cased characters in the subject some are upper-case.<br />
	///     That is, that the string could not be the result of a call to <see cref="string.ToLowerInvariant()" />,
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeLowerCased(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<string>(
					"",
					_ => "not be lower-cased",
					(a, _) => a == null || a != a.ToLowerInvariant(),
					(a, _) => $"found {Formatter.Format(a.DisplayWhitespace().TruncateWithEllipsis(100))}")),
			source);
}
