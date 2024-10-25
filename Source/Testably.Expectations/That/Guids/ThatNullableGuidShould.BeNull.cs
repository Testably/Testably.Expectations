using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableGuidShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<Guid?, IThat<Guid?>> BeNull(this IThat<Guid?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be null",
					actual => actual == null),
				b => b.AppendMethod(nameof(BeNull))),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<Guid?, IThat<Guid?>> NotBeNull(this IThat<Guid?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be null",
					actual => actual != null),
				b => b.AppendMethod(nameof(NotBeNull))),
			source);
}
