using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> HaveLength(
		this IThat<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"have length {expected}",
					actual => actual?.Length == expected,
					actual => actual == null ? "found <null>" : $"it had length {actual.Length}"))
				.AppendMethodStatement(nameof(HaveLength), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> NotHaveLength(
		this IThat<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"not have length {expected}",
					actual => actual != null && actual.Length != expected,
					actual => actual == null ? "found <null>" : "it had"))
				.AppendMethodStatement(nameof(NotHaveLength), doNotPopulateThisValue),
			source);
}
