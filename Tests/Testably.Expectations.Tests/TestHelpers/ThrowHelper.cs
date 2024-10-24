using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations.Tests.TestHelpers;

public static class ThrowHelper
{
	/// <summary>
	///     Verifies that the message of the thrown exception also matches the <paramref name="expected" /> pattern.
	/// </summary>
	public static StringMatcherExpectationResult<Exception?, That<Exception?>> AndWithMessage(
		this StringMatcherExpectationResult<Exception?, That<Exception?>> source,
		string expected)
	{
		return source.And.HasMessage(expected).AsWildcard();
	}

	/// <summary>
	///     Verifies that the delegate throws an exception which has a message matching the <paramref name="expected" />
	///     pattern.
	/// </summary>
	public static StringMatcherExpectationResult<Exception, That<Exception>> ThrowsWithMessage(
		this ThatDelegate source,
		string expected)
	{
		return source.ThrowException().Which.HasMessage(expected).AsWildcard();
	}
}
