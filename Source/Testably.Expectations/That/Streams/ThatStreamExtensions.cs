using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Stream" /> values.
/// </summary>
public static partial class ThatStreamExtensions
{
	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not writable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsNotWritable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is not writable",
					actual => actual?.CanWrite == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(IsNotWritable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is writable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsWritable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is writable",
					actual => actual?.CanWrite == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(IsWritable))),
			source);
}
