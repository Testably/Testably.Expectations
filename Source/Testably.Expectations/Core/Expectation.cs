using System.Diagnostics;
using Testably.Expectations.Core.ExpectationBuilders;

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
public class Expectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal Expectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Combines the expectation with another expectation using AND.
	/// </summary>
	/// <remarks>Both expectations must be met by the actual value.</remarks>
	public ExpectationWhichShould<TExpectation, TProperty> And()
		=> new(new AndExpectationBuilder(_expectationBuilder));

	/// <summary>
	///     Combines the expectation with another expectation using OR.
	/// </summary>
	/// <remarks>At least one expectation must be met by the actual value.</remarks>
	public ExpectationWhichShould<TExpectation, TProperty> Or()
		=> new(new OrExpectationBuilder(_expectationBuilder));

	internal ExpectationResult ApplyTo(TExpectation actual)
		=> _expectationBuilder.ApplyTo(actual);

	/// <inheritdoc />
	public override string ToString()
		=> $"Expect {_expectationBuilder}";
}
