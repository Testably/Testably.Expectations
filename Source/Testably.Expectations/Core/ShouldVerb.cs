using System;
using System.ComponentModel;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     A verb for allowing extension methods on <see cref="Should" /> properties.
/// </summary>
public abstract class ShouldVerb
{
	private readonly IExpectationBuilderStart _expectationBuilder;

	internal ShouldVerb(IExpectationBuilderStart expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Adds an expectation.
	/// </summary>
	/// <remarks>This is called from the extension methods.</remarks>
	public Expectation<T> WithExpectation<T>(IExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	/// <summary>
	///     Adds a nullable expectation.
	/// </summary>
	/// <remarks>This is called from the extension methods.</remarks>
	public NullableExpectation<T> WithExpectation<T>(INullableExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	/// <summary>
	///     Adds a complex expectation.
	/// </summary>
	/// <remarks>This is called from the extension methods.</remarks>
	public ExpectationWhichShould<T1, T2> WithExpectation<T1, T2>(
		IExpectation<T1, T2> expectation)
		=> new(_expectationBuilder.Add(expectation));

	#pragma warning disable CS0809
	/// <inheritdoc />
	[Obsolete]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object? obj)
		=> throw new NotSupportedException(
			"Equals is not part of Testably.Expectations.");

	/// <inheritdoc />
	[Obsolete]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
		=> throw new NotSupportedException(
			"Equals is not part of Testably.Expectations.");
	#pragma warning restore CS0809
}
