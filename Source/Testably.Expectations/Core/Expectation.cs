using System.Diagnostics;

namespace Testably.Expectations.Core;

/// <summary>
///     A simple expectation on type <typeparamref name="TExpectation" />.
/// </summary>
[StackTraceHidden]
public class Expectation<TExpectation> : Expectation<TExpectation, TExpectation>
{
	internal Expectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder) { }
}

/// <summary>
///     A complex expectation from type <typeparamref name="TExpectation" /> to type <typeparamref name="TProperty" />.
/// </summary>
[StackTraceHidden]
public class Expectation<TExpectation, TProperty> : IExpectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal Expectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	#region IExpectation<TExpectation,TProperty> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(TExpectation actual)
		=> _expectationBuilder.IsMetBy(actual);

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
		=> $"Expect {_expectationBuilder}";
}
