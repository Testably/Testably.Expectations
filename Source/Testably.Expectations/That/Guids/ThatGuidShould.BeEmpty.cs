using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatGuidShould
{
	/// <summary>
	///     Verifies that the subject is empty.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> BeEmpty(this That<Guid> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be empty",
					actual => actual == Guid.Empty),
				b => b.AppendMethod(nameof(BeEmpty))),
			source);

	/// <summary>
	///     Verifies that the subject is not empty.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> NotBeEmpty(this That<Guid> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be empty",
					actual => actual != Guid.Empty),
				b => b.AppendMethod(nameof(NotBeEmpty))),
			source);
}
