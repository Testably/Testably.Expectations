using System;
using System.Text;
using System.Threading.Tasks;

namespace Testably.Expectations.Core;

internal interface IExpectationBuilder
{
	IFailureMessageBuilder FailureMessageBuilder { get; }
	IExpectationBuilder Add(IExpectation expectation, Action<StringBuilder> expressionBuilder);
	IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation, Action<StringBuilder> expressionBuilde);
	IExpectationBuilder And(Action<StringBuilder> expressionBuilder, string textSeparator = " and ");
	Task<ExpectationResult> IsMet();
	IExpectationBuilder Not();
	IExpectationBuilder Or();

	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		IExpectation<TProperty> expectation);

	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		Action<StringBuilder> expressionBuilder, string textSeparator = "");
}
