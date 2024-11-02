#if NET6_0_OR_GREATER
using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatBufferedStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrResult<BufferedStream?, IThat<BufferedStream?>> HaveBufferSize(
		this IThat<BufferedStream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"have buffer size {expected}",
					actual => actual?.BufferSize == expected,
					actual => actual == null
						? "found <null>"
						: $"it had buffer size {actual.BufferSize}"))
				.AppendMethodStatement(nameof(HaveBufferSize), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrResult<BufferedStream?, IThat<BufferedStream?>>
		NotHaveBufferSize(this IThat<BufferedStream?> source,
			long expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"not have buffer size {expected}",
					actual => actual != null && actual.BufferSize != expected,
					actual => actual == null ? "found <null>" : "it had"))
				.AppendMethodStatement(nameof(NotHaveBufferSize), doNotPopulateThisValue),
			source);
}
#endif
