using System;
using System.ComponentModel;

namespace Testably.Expectations.Core;

/// <summary>
///     A verb for allowing extension methods on <see cref="Should" /> properties.
/// </summary>
public abstract class ShouldVerb
{
	private readonly IExpectationBuilder _expectationBuilder;

	private protected ShouldVerb(IExpectationBuilder expectationBuilder)
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
		=> new(_expectationBuilder.AddCast(expectation));

	#pragma warning disable CS0809
	/// <inheritdoc />
	[Obsolete("Equals is not part of Testably.Expectations.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object? obj)
		// ReSharper disable once BaseObjectEqualsIsObjectEquals
		=> base.Equals(obj);

	/// <inheritdoc />
	[Obsolete("Equals is not part of Testably.Expectations.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
		// ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
		=> base.GetHashCode();
	#pragma warning restore CS0809
}
