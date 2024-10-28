using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is readable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> BeReadable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new ValueConstraint(
					"be readable",
					actual => actual?.CanRead == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(BeReadable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not readable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> NotBeReadable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new ValueConstraint(
					"not be readable",
					actual => actual?.CanRead == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(NotBeReadable))),
			source);
}
