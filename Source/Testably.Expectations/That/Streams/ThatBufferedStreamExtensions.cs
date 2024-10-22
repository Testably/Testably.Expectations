#if NET6_0_OR_GREATER
using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="BufferedStream" /> values.
/// </summary>
public static partial class ThatBufferedStreamExtensions
{
	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrExpectationResult<BufferedStream?, That<BufferedStream?>>
		DoesNotHaveBufferSize(this That<BufferedStream?> source,
			long expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"does not have buffer size {expected}",
					actual => actual != null && actual.BufferSize != expected,
					actual => actual == null ? "found <null>" : "it had"),
				b => b.AppendMethod(nameof(DoesNotHaveBufferSize), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrExpectationResult<BufferedStream?, That<BufferedStream?>> HasBufferSize(
		this That<BufferedStream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"has buffer size {expected}",
					actual => actual?.BufferSize == expected,
					actual => actual == null
						? "found <null>"
						: $"it had buffer size {actual.BufferSize}"),
				b => b.AppendMethod(nameof(HasBufferSize), doNotPopulateThisValue)),
			source);
}
#endif
