using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> BeNull(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<string>(
					"",
					_ => "be null",
					(a, _) => a is null,
					(a, _) => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotBeNull(
		this IThat<string?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<string>(
					"",
					_ => "not be null",
					(a, _) => a is not null,
					(_, _) => "it was")),
			source);
}
