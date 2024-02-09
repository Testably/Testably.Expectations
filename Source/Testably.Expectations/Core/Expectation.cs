using System;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class Expectation<TExpectation> : Expectation<TExpectation, TExpectation>
{
	internal Expectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder) { }
}

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

public class Expectation
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal Expectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public IShould And() => throw new NotImplementedException();

	internal ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
		=> _expectationBuilder.ApplyTo(actual);
}
