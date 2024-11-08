using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> position.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> HavePosition(
		this IThat<Stream?> source,
		long expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"have position {expected}",
					actual => actual?.Position == expected,
					actual => actual == null
						? "found <null>"
						: $"it had position {actual.Position}")),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> position.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> NotHavePosition(
		this IThat<Stream?> source,
		long expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"not have position {expected}",
					actual => actual != null && actual.Position != expected,
					actual => actual == null ? "found <null>" : "it had")),
			source);
}
