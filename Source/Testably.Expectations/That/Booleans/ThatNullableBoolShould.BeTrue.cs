using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="true" />.
	/// </summary>
	public static AndOrResult<bool?, IThat<bool?>> BeTrue(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint(true)),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="true" />.
	/// </summary>
	public static AndOrResult<bool?, IThat<bool?>> NotBeTrue(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotValueConstraint(true)),
			source);
}
