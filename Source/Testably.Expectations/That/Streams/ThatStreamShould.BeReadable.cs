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
	public static AndOrExpectationResult<Stream?, That<Stream?>> BeReadable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"be readable",
					actual => actual?.CanRead == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(BeReadable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not readable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> NotBeReadable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"not be readable",
					actual => actual?.CanRead == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(NotBeReadable))),
			source);
}
