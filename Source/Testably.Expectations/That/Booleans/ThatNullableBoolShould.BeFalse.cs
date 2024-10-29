using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="false" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> BeFalse(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint(false))
				.AppendMethodStatement(nameof(BeFalse)),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="false" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> NotBeFalse(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotValueConstraint(false))
				.AppendMethodStatement(nameof(NotBeFalse)),
			source);
}
