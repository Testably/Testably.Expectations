using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations.Tests.TestHelpers;

public static class ThrowHelper
{
	/// <summary>
	///     Verifies that the message of the thrown exception also matches the <paramref name="expected" /> pattern.
	/// </summary>
	public static StringMatcherExpectationResult<Exception?, ThatExceptionShould<Exception?>> AndWithMessage(
		this StringMatcherExpectationResult<Exception?, ThatExceptionShould<Exception?>> source,
		string expected)
	{
		return source.And.HaveMessage(expected).AsWildcard();
	}

	/// <summary>
	///     Verifies that the delegate throws an exception which has a message matching the <paramref name="expected" />
	///     pattern.
	/// </summary>
	public static StringMatcherExpectationResult<Exception, ThatExceptionShould<Exception?>> ThrowWithMessage(
		this ThatDelegate source,
		string expected)
	{
		return source.ThrowException().Which.HaveMessage(expected).AsWildcard();
	}
}
