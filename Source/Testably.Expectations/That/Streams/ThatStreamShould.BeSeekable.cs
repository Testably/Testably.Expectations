using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is seekable.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> BeSeekable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"be seekable",
					actual => actual?.CanSeek == true,
					actual => actual == null ? "found <null>" : "it was not"))
				.AppendMethodStatement(nameof(BeSeekable)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not seekable.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> NotBeSeekable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"not be seekable",
					actual => actual?.CanSeek == false,
					actual => actual == null ? "found <null>" : "it was"))
				.AppendMethodStatement(nameof(NotBeSeekable)),
			source);
}
