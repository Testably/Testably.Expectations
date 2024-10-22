using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Guid" /> values.
/// </summary>
public static partial class ThatGuidExtensions
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> Is(this That<Guid> source,
		Guid expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"is {Formatter.Format(expected)}",
					actual => actual.Equals(expected)),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> IsNot(this That<Guid> source,
		Guid unexpected,
		[CallerArgumentExpression("unexpected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"is not {Formatter.Format(unexpected)}",
					actual => !actual.Equals(unexpected)),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is empty.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> IsEmpty(this That<Guid> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is empty",
					actual => actual == Guid.Empty),
				b => b.AppendMethod(nameof(IsEmpty))),
			source);

	/// <summary>
	///     Verifies that the subject is not empty.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> IsNotEmpty(this That<Guid> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is not empty",
					actual => actual != Guid.Empty),
				b => b.AppendMethod(nameof(IsNotEmpty))),
			source);
}
