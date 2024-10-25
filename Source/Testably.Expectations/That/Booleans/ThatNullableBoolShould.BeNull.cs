using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> BeNull(this IThat<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(null),
				b => b.AppendMethod(nameof(BeNull))),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> NotBeNull(this IThat<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotConstraint(null),
				b => b.AppendMethod(nameof(NotBeNull))),
			source);
}
