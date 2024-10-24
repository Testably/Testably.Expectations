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
	public static AndOrExpectationResult<bool?, That<bool?>> BeTrue(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(true),
				b => b.AppendMethod(nameof(BeTrue))),
			source);
}
