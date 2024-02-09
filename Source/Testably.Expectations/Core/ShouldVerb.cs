using System.ComponentModel;
using System;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     A verb for allowing extension methods on <see cref="Should"/> properties.
/// </summary>
public abstract class ShouldVerb
{
	private readonly IExpectationBuilderStart _expectationBuilder;

	internal ShouldVerb(IExpectationBuilderStart expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	/// 
	/// </summary>
	public Expectation<T> WithExpectation<T>(IExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	public NullableExpectation<T> WithExpectation<T>(INullableExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	public ExpectationWhich<T1, T2> WithExpectation<T1, T2>(
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
