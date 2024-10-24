using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<bool?, That<bool?>> NotBeNull(this That<bool?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotConstraint(null),
				b => b.AppendMethod(nameof(NotBeNull))),
			source);
}
