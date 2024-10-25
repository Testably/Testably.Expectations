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
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> position.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> HavePosition(
		this IThat<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"have position {expected}",
					actual => actual?.Position == expected,
					actual => actual == null
						? "found <null>"
						: $"it had position {actual.Position}"),
				b => b.AppendMethod(nameof(HavePosition), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> position.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> NotHavePosition(
		this IThat<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"not have position {expected}",
					actual => actual != null && actual.Position != expected,
					actual => actual == null ? "found <null>" : "it had"),
				b => b.AppendMethod(nameof(NotHavePosition), doNotPopulateThisValue)),
			source);
}
