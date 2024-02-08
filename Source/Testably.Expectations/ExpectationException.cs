using System;

namespace Testably.Expectations;

/// <summary>
///     Represents the default exception in case no test framework is configured.
/// </summary>
public class ExpectationException(string message) : Exception(message);
