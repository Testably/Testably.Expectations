using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="false" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> BeFalse(this IThat<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsValueConstraint(false),
				b => b.AppendMethod(nameof(BeFalse))),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="false" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> NotBeFalse(this IThat<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotValueConstraint(false),
				b => b.AppendMethod(nameof(NotBeFalse))),
			source);
}
