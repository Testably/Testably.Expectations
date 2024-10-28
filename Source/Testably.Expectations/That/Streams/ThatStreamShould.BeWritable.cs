using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is writable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> BeWritable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new ValueConstraint(
					"be writable",
					actual => actual?.CanWrite == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(BeWritable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not writable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, IThat<Stream?>> NotBeWritable(
		this IThat<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new ValueConstraint(
					"not be writable",
					actual => actual?.CanWrite == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(NotBeWritable))),
			source);
}
