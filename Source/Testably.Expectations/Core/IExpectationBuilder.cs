/* Unmerged change from project 'Testably.Expectations (net6.0)'
Before:
namespace Testably.Expectations.Core.ExpectationBuilders;
After:
using Testably;
using Testably.Expectations;
using Testably.Expectations.Core;
using Testably.Expectations.Core;
using Testably.Expectations.Core.ExpectationBuilders;
*/
namespace Testably.Expectations.Core;

internal interface IExpectationBuilder
{
	IExpectationBuilder Add(IExpectation expectation);
	IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation);
	IExpectationBuilder And();
	ExpectationResult ApplyTo<TExpectation>(TExpectation actual);
	IExpectationBuilder Not();
	IExpectationBuilder Or();
	IExpectationBuilder Which<TSource, TProperty>(string property,
		IExpectation<TProperty> expectation);
}
