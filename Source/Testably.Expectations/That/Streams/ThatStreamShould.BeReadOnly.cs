using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is read-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> BeReadOnly(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be read-only",
					actual => actual is { CanWrite: false, CanRead: true },
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(BeReadOnly))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not read-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> NotBeReadOnly(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be read-only",
					actual => actual != null && !(actual is { CanWrite: false, CanRead: true }),
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(NotBeReadOnly))),
			source);
}
