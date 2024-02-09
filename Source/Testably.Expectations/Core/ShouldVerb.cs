using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public abstract class ShouldVerb
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal ShouldVerb(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}
	internal Expectation<T> WithExpectation<T>(IExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	internal NullableExpectation<T> WithExpectation<T>(INullableExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	internal Expectation WithExpectation(IExpectation expectation)
		=> new(_expectationBuilder.Add(expectation));

	internal NullableExpectation WithExpectation(INullableExpectation expectation)
		=> new(_expectationBuilder.Add(expectation));

	internal ExpectationWhich<T1, T2> WithExpectationMapping<T1, T2>(
		IExpectation<T1, T2> expectation)
		=> new(_expectationBuilder.Add(expectation));
}
