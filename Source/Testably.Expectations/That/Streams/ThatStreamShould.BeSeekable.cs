using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is seekable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> BeSeekable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be seekable",
					actual => actual?.CanSeek == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(BeSeekable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not seekable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> NotBeSeekable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be seekable",
					actual => actual?.CanSeek == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(NotBeSeekable))),
			source);
}
