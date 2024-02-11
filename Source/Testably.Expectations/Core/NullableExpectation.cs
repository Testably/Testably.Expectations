using System.Diagnostics;

namespace Testably.Expectations.Core;

/// <summary>
///     A simple nullable expectation on type <typeparamref name="TExpectation" />.
/// </summary>
[StackTraceHidden]
public class NullableExpectation<TExpectation> : NullableExpectation<TExpectation, TExpectation>
{
	internal NullableExpectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
	{
	}
}

/// <summary>
///     A complex nullable expectation from type <typeparamref name="TExpectation" /> to type
///     <typeparamref name="TProperty" />.
/// </summary>
[StackTraceHidden]
public class NullableExpectation<TExpectation, TProperty> : IExpectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal NullableExpectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	#region IExpectation<TExpectation,TProperty> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(TExpectation? actual)
		=> _expectationBuilder.ApplyTo(actual);

	#endregion

	/// <summary>
	///     Combines the expectation with another expectation using AND.
	/// </summary>
	/// <remarks>Both expectations must be met by the actual value.</remarks>
	public ExpectationWhichShould<TExpectation, TProperty> And()
		=> new(_expectationBuilder.And());

	/// <summary>
	///     Combines the expectation with another expectation using OR.
	/// </summary>
	/// <remarks>At least one expectation must be met by the actual value.</remarks>
	public ExpectationWhichShould<TExpectation, TProperty> Or()
		=> new(_expectationBuilder.Or());

	/// <inheritdoc />
	public override string ToString()
		=> $"expect {_expectationBuilder}";
}
