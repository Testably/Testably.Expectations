using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="false" />.
	/// </summary>
	public static AndOrResult<bool, IThat<bool>> BeFalse(this IThat<bool> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint(false))
				.AppendMethodStatement(nameof(BeFalse)),
			source);
}
