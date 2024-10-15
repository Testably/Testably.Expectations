using System;

namespace TUnit.Assertions.Exceptions;

/// <summary>
///     Represents the default exception in case no test framework is configured.
/// </summary>
public class AssertionException(string message) : Exception(message);
