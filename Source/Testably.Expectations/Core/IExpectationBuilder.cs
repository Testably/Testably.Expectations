using System;
using System.Text;
using System.Threading.Tasks;

namespace Testably.Expectations.Core;

internal interface IExpectationBuilder
{
	IExpectationBuilder Add(IExpectation expectation, Action<StringBuilder> expressionBuilder);
	IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation);
	IExpectationBuilder And();
	Task<ExpectationResult> IsMet();
	IExpectationBuilder Not();
	IExpectationBuilder Or();

	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		IExpectation<TProperty> expectation);

	IFailureMessageBuilder FailureMessageBuilder { get; }
}
