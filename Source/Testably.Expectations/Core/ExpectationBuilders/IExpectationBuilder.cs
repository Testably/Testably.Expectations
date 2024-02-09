namespace Testably.Expectations.Core.ExpectationBuilders;

internal interface IExpectationBuilder
{
	IExpectationBuilder Add(IExpectation expectation);
	ExpectationResult ApplyTo<TExpectation>(TExpectation actual);
}
