using System;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableGuidShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<Guid?, IThat<Guid?>> BeNull(this IThat<Guid?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"be null",
					actual => actual == null))
				.AppendMethodStatement(nameof(BeNull)),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<Guid?, IThat<Guid?>> NotBeNull(this IThat<Guid?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"not be null",
					actual => actual != null))
				.AppendMethodStatement(nameof(NotBeNull)),
			source);
}
