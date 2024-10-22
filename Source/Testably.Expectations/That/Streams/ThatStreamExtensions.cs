using System;
using System.IO;
using System.Runtime.CompilerServices;
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
	///     Verifies that the subject <see cref="Stream" /> is not readable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsNotReadable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is not readable",
					actual => actual?.CanRead == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(IsNotReadable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not read-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsNotReadOnly(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is not read-only",
					actual => actual != null && !(actual is { CanWrite: false, CanRead: true }),
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(IsNotReadOnly))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is not seekable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsNotSeekable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is not seekable",
					actual => actual?.CanSeek == false,
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(IsNotSeekable))),
			source);

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
	///     Verifies that the subject <see cref="Stream" /> is not write-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsNotWriteOnly(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is not write-only",
					actual => actual != null && !(actual is { CanWrite: true, CanRead: false }),
					actual => actual == null ? "found <null>" : "it was"),
				b => b.AppendMethod(nameof(IsNotWriteOnly))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is readable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsReadable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is readable",
					actual => actual?.CanRead == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(IsReadable))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is read-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsReadOnly(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is read-only",
					actual => actual is { CanWrite: false, CanRead: true },
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(IsReadOnly))),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is seekable.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsSeekable(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is seekable",
					actual => actual?.CanSeek == true,
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(IsSeekable))),
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

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> is write-only.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> IsWriteOnly(
		this That<Stream?> source)
		=> new(source.ExpectationBuilder.Add(new Constraint(
					"is write-only",
					actual => actual is { CanWrite: true, CanRead: false },
					actual => actual == null ? "found <null>" : "it was not"),
				b => b.AppendMethod(nameof(IsWriteOnly))),
			source);


	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> HasLength(this That<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"has length {expected}",
					actual => actual?.Length == expected,
					actual => actual == null ? "found <null>" : $"it had length {actual.Length}"),
				b => b.AppendMethod(nameof(HasLength), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> position.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> HasPosition(this That<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"has position {expected}",
					actual => actual?.Position == expected,
					actual => actual == null ? "found <null>" : $"it had position {actual.Position}"),
				b => b.AppendMethod(nameof(HasPosition), doNotPopulateThisValue)),
			source);


	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> DoesNotHaveLength(this That<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"does not have length {expected}",
					actual => actual != null && actual.Length != expected,
					actual => actual == null ? "found <null>" : "it had"),
				b => b.AppendMethod(nameof(DoesNotHaveLength), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="Stream" /> has the <paramref name="expected" /> position.
	/// </summary>
	public static AndOrExpectationResult<Stream?, That<Stream?>> DoesNotHavePosition(this That<Stream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"does not have position {expected}",
					actual => actual != null && actual.Position != expected,
					actual => actual == null ? "found <null>" : "it had"),
				b => b.AppendMethod(nameof(DoesNotHavePosition), doNotPopulateThisValue)),
			source);

}
