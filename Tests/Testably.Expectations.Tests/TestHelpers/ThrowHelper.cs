using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Results;
using Testably.Expectations.Expectations;

namespace Testably.Expectations.Tests.TestHelpers;

public static class ThrowHelper
{
	/// <summary>
	///     Verifies that the delegate throws an exception which has a message matching <paramref name="expected" />
	/// </summary>
	public static MatcherAssertionResult<Exception, That<Exception?>> ThrowsWithMessage(
		this ThatDelegate source,
		string expected)
	{
		return source.ThrowsException().Which.HasMessage(expected).AsWildcard();
	}
}
