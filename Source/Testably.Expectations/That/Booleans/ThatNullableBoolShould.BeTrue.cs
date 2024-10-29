using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="true" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> BeTrue(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint(true))
				.AppendMethodStatement(nameof(BeTrue)),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="true" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> NotBeTrue(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotValueConstraint(true))
				.AppendMethodStatement(nameof(NotBeTrue)),
			source);
}
