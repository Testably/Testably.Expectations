namespace Testably.Expectations.Core.ExpectationBuilders;

internal interface IExpectationBuilder
{
	ExpectationResult ApplyTo<TExpectation>(TExpectation actual);
}

internal interface IExpectationBuilderStart : IExpectationBuilder
{
	IExpectationBuilderStart Add(IExpectation expectation);
}


internal interface IExpectationBuilderCombination : IExpectationBuilder
{
	IExpectationBuilder Left { get; }
}
