using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is write-only.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> BeWriteOnly(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"be write-only",
					actual => actual is { CanWrite: true, CanRead: false },
					actual => actual == null ? "found <null>" : "it was not"))
				.AppendMethodStatement(nameof(BeWriteOnly)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not write-only.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> NotBeWriteOnly(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"not be write-only",
					actual => actual != null && !(actual is { CanWrite: true, CanRead: false }),
					actual => actual == null ? "found <null>" : "it was"))
				.AppendMethodStatement(nameof(NotBeWriteOnly)),
			source);
}
