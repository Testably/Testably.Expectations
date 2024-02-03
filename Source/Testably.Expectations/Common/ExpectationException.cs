using System;

namespace Testably.Expectations.Common;

/// <summary>
/// Represents the default exception in case no test framework is configured.
/// </summary>
public class ExpectationException : Exception
{
	public ExpectationException(string message)
		: base(message)
	{
	}
}
