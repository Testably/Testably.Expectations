﻿namespace Testably.Expectations.Core;

/// <summary>
///     Starting point for an expectation.
/// </summary>
public interface IExpectThat<out T>
{
	/// <summary>
	///     The expectation builder.
	/// </summary>
	IExpectationBuilder ExpectationBuilder { get; }
}