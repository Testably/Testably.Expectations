using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is writable.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> BeWritable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"be writable",
					actual => actual?.CanWrite == true,
					actual => actual == null ? "found <null>" : "it was not")),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not writable.
	/// </summary>
	public static AndOrResult<Stream?, IThat<Stream?>> NotBeWritable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					"not be writable",
					actual => actual?.CanWrite == false,
					actual => actual == null ? "found <null>" : "it was")),
			source);
}
