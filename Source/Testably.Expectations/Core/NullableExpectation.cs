using System.Diagnostics;
using Testably.Expectations.Core.ExpectationBuilders;

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
public class NullableExpectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal NullableExpectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Combines the expectation with another expectation using AND.
	/// </summary>
	/// <remarks>Both expectations must be met by the actual value.</remarks>
	public ExpectationWhich<TExpectation, TProperty> And()
		=> new(new AndExpectationBuilder(_expectationBuilder));

	/// <summary>
	///     Combines the expectation with another expectation using OR.
	/// </summary>
	/// <remarks>At least one expectation must be met by the actual value.</remarks>
	public ExpectationWhich<TExpectation, TProperty> Or()
		=> new(new OrExpectationBuilder(_expectationBuilder));

	internal ExpectationResult ApplyTo(TExpectation? actual)
		=> _expectationBuilder.ApplyTo(actual);
}
