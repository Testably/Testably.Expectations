using System;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatGuidShould
{
	/// <summary>
	///     Verifies that the subject is empty.
	/// </summary>
	public static AndOrResult<Guid, IThat<Guid>> BeEmpty(this IThat<Guid> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"be empty",
					actual => actual == Guid.Empty))
				.AppendMethodStatement(nameof(BeEmpty)),
			source);

	/// <summary>
	///     Verifies that the subject is not empty.
	/// </summary>
	public static AndOrResult<Guid, IThat<Guid>> NotBeEmpty(this IThat<Guid> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"not be empty",
					actual => actual != Guid.Empty))
				.AppendMethodStatement(nameof(NotBeEmpty)),
			source);
}
