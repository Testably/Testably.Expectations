using System.Diagnostics;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

[StackTraceHidden]
public class Expectation<TExpectation> : Expectation<TExpectation, TExpectation>
{
	internal Expectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder) { }
}

[StackTraceHidden]
public class Expectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal Expectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public ExpectationWhich<TExpectation, TProperty> And()
		=> new(new AndExpectationBuilder(_expectationBuilder));

	public ExpectationWhich<TExpectation, TProperty> Or()
		=> new(new OrExpectationBuilder(_expectationBuilder));

	internal ExpectationResult ApplyTo(TExpectation actual)
		=> _expectationBuilder.ApplyTo(actual);
}
