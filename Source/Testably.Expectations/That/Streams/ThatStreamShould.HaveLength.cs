using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> HaveLength(
		this That<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"have length {expected}",
					actual => actual?.Length == expected,
					actual => actual == null ? "found <null>" : $"it had length {actual.Length}"),
				b => b.AppendMethod(nameof(HaveLength), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> NotHaveLength(
		this That<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"not have length {expected}",
					actual => actual != null && actual.Length != expected,
					actual => actual == null ? "found <null>" : "it had"),
				b => b.AppendMethod(nameof(NotHaveLength), doNotPopulateThisValue)),
			source);
}
