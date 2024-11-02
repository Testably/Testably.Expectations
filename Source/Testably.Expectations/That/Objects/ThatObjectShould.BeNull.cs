using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectShould
{
	/// <summary>
	///     Verifies that the subject is null.
	/// </summary>
	public static AndOrResult<object?, IThat<object?>> BeNull(
		this IThat<object?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<object?>(
					null,
					"be null",
					(a, _) => a is null,
					(a, _) => $"found {Formatter.Format(a)}"))
				.AppendMethodStatement(nameof(BeNull)),
			source);

	/// <summary>
	///     Verifies that the subject is not null.
	/// </summary>
	public static AndOrResult<object, IThat<object?>> NotBeNull(
		this IThat<object?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<object?>(
					null,
					"not be null",
					(a, _) => a is not null,
					(_, _) => "it was"))
				.AppendMethodStatement(nameof(NotBeNull)),
			source);
}
