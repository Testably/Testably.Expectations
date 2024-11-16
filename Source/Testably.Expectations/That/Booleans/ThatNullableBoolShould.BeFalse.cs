using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="false" />.
	/// </summary>
	public static AndOrResult<bool?, IThat<bool?>> BeFalse(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(it => new IsValueConstraint(it, false)),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="false" />.
	/// </summary>
	public static AndOrResult<bool?, IThat<bool?>> NotBeFalse(this IThat<bool?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(it => new IsNotValueConstraint(it, false)),
			source);
}
