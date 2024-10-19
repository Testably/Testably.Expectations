using System;
using System.Text;
using System.Threading.Tasks;

namespace Testably.Expectations.Core;

public interface IExpectationBuilder
{
	IFailureMessageBuilder FailureMessageBuilder { get; }
	IExpectationBuilder Add(IExpectation expectation, Action<StringBuilder> expressionBuilder);
	IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation, Action<StringBuilder> expressionBuilder);
	IExpectationBuilder And(Action<StringBuilder> expressionBuilder, string textSeparator = " and ");
	IExpectationBuilder Or(Action<StringBuilder> expressionBuilder, string textSeparator = " or ");
	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		Action<That<TProperty>> expectation,
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " which ");

	IExpectationBuilder WhichCast<TSource, TBase, TProperty>(PropertyAccessor propertyAccessor,
		IExpectation<TBase, TProperty> cast,
		Action<That<TProperty>> expectation,
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " which ")
		where TProperty : TBase;
	IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		Action<StringBuilder> expressionBuilder, string textSeparator = "");
	Task<ExpectationResult> IsMet();
}
