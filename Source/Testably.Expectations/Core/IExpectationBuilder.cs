using System.Threading.Tasks;

namespace Testably.Expectations.Core;

internal interface IExpectationBuilder
{
	IExpectationBuilder Add(IExpectation expectation);
	IExpectationBuilder Add(IAsyncExpectation expectation);
	IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation);
	IExpectationBuilder AddCast<T1, T2>(IAsyncExpectation<T1, T2> expectation);
	IExpectationBuilder And();
	ExpectationResult IsMetBy<TExpectation>(TExpectation actual);
	Task<ExpectationResult> IsMetByAsync<TExpectation>(TExpectation actual);
	IExpectationBuilder Not();
	IExpectationBuilder Or();

	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		IExpectation<TProperty> expectation);

	IExpectationBuilder WhichAsync<TSource, TProperty>(PropertyAccessor propertyAccessor,
		IAsyncExpectation<TProperty> expectation);
}
