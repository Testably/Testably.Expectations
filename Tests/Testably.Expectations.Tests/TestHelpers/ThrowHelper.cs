using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Results;
using Testably.Expectations.Expectations;

namespace Testably.Expectations.Tests.TestHelpers;

public static class ThrowHelper
{
	/// <summary>
	///     Verifies that the message of the thrown exception also matches the <paramref name="expected" /> pattern.
	/// </summary>
	public static MatcherExpectationResult<Exception, That<Exception?>> AndWithMessage(
		this MatcherExpectationResult<Exception, That<Exception?>> source,
		string expected)
	{
		return source.And.HasMessage(expected).AsWildcard();
	}

	/// <summary>
	///     Verifies that the delegate throws an exception which has a message matching the <paramref name="expected" />
	///     pattern.
	/// </summary>
	public static MatcherExpectationResult<Exception, That<Exception?>> ThrowsWithMessage(
		this ThatDelegate source,
		string expected)
	{
		return source.ThrowsException().Which.HasMessage(expected).AsWildcard();
	}
}
