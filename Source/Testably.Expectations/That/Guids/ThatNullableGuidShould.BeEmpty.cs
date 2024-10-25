using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableGuidShould
{
	/// <summary>
	///     Verifies that the subject is empty.
	/// </summary>
	public static AndOrExpectationResult<Guid?, IThat<Guid?>> BeEmpty(this IThat<Guid?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be empty",
					actual => actual != null && actual == Guid.Empty),
				b => b.AppendMethod(nameof(BeEmpty))),
			source);

	/// <summary>
	///     Verifies that the subject is not empty.
	/// </summary>
	public static AndOrExpectationResult<Guid?, IThat<Guid?>> NotBeEmpty(this IThat<Guid?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be empty",
					actual => actual != null && actual != Guid.Empty),
				b => b.AppendMethod(nameof(NotBeEmpty))),
			source);
}
