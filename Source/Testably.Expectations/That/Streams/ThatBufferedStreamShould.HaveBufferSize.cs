#if NET6_0_OR_GREATER
using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatBufferedStreamShould
{
	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrExpectationResult<BufferedStream?, That<BufferedStream?>>
		NotHaveBufferSize(this That<BufferedStream?> source,
			long expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"not have buffer size {expected}",
					actual => actual != null && actual.BufferSize != expected,
					actual => actual == null ? "found <null>" : "it had"),
				b => b.AppendMethod(nameof(NotHaveBufferSize), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject <see cref="BufferedStream" /> has the <paramref name="expected" /> buffer size.
	/// </summary>
	public static AndOrExpectationResult<BufferedStream?, That<BufferedStream?>> HaveBufferSize(
		this That<BufferedStream?> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"have buffer size {expected}",
					actual => actual?.BufferSize == expected,
					actual => actual == null
						? "found <null>"
						: $"it had buffer size {actual.BufferSize}"),
				b => b.AppendMethod(nameof(HaveBufferSize), doNotPopulateThisValue)),
			source);
}
#endif
