namespace Testably.Expectations.Core;

internal interface IExpectationBuilder
{
	IExpectationBuilder Add(IExpectation expectation);
	IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation);
	IExpectationBuilder And();
	ExpectationResult IsMetBy<TExpectation>(TExpectation actual);
	IExpectationBuilder Not();
	IExpectationBuilder Or();

	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		IExpectation<TProperty> expectation);
}
