using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is write-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> BeWriteOnly(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be write-only",
					actual => actual is { CanWrite: true, CanRead: false },
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(BeWriteOnly))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not write-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> NotBeWriteOnly(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be write-only",
					actual => actual != null && !(actual is { CanWrite: true, CanRead: false }),
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(NotBeWriteOnly))),
			source);
}
