using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class NullableExpectation<TExpectation> : NullableExpectation<TExpectation, TExpectation>
{
	internal NullableExpectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
	{
	}
}

public class NullableExpectation<TExpectation, TProperty>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal NullableExpectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public ExpectationWhich<TExpectation, TProperty> And()
		=> new(new AndExpectationBuilder(_expectationBuilder));

	public ExpectationWhich<TExpectation, TProperty> Or()
		=> new(new OrExpectationBuilder(_expectationBuilder));

	internal ExpectationResult ApplyTo(TExpectation? actual)
		=> _expectationBuilder.ApplyTo(actual);
}
