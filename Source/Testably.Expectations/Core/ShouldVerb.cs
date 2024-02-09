using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public abstract class ShouldVerb
{
	private readonly IExpectationBuilderStart _expectationBuilder;

	internal ShouldVerb(IExpectationBuilderStart expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public Expectation<T> WithExpectation<T>(IExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	public NullableExpectation<T> WithExpectation<T>(INullableExpectation<T> expectation)
		=> new(_expectationBuilder.Add(expectation));

	public ExpectationWhich<T1, T2> WithExpectation<T1, T2>(
		IExpectation<T1, T2> expectation)
		=> new(_expectationBuilder.Add(expectation));
}
