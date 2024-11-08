#if NET6_0_OR_GREATER
using System.IO;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatBufferedStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrResult<BufferedStream?, IThat<BufferedStream?>> HaveBufferSize(
		this IThat<BufferedStream?> source,
		int expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"have buffer size {expected}",
					actual => actual?.BufferSize == expected,
					actual => actual == null
						? "found <null>"
						: $"it had buffer size {actual.BufferSize}")),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> does not have the <paramref name="unexpected" />
	///     buffer size.
	/// </summary>
	public static AndOrResult<BufferedStream?, IThat<BufferedStream?>>
		NotHaveBufferSize(this IThat<BufferedStream?> source,
			int unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"not have buffer size {unexpected}",
					actual => actual != null && actual.BufferSize != unexpected,
					actual => actual == null ? "found <null>" : "it had")),
			source);
}
#endif
