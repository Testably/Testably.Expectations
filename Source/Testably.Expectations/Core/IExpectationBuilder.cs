using System;
using System.Text;
using System.Threading.Tasks;

namespace Testably.Expectations.Core;

/// <summary>
///     The builder for collecting all expectations.
/// </summary>
public interface IExpectationBuilder
{
	/// <summary>
	///     The builder for the failure message.
	/// </summary>
	IFailureMessageBuilder FailureMessageBuilder { get; }

	/// <summary>
	///     Add a new <paramref name="expectation" />.
	///     Also update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder Add(
		IExpectation expectation,
		Action<StringBuilder> expressionBuilder);

	/// <summary>
	///     Add a new <paramref name="expectation" /> that casts from <typeparamref name="TSource" /> to
	///     <typeparamref name="TTarget" />.
	///     Also update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder AddCast<TSource, TTarget>(
		IExpectation<TSource, TTarget> expectation,
		Action<StringBuilder> expressionBuilder);

	/// <summary>
	///     Add an AND node, using the <paramref name="textSeparator" />.
	///     Also update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder And(
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " and ");

	/// <summary>
	///     Update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder AppendExpression(
		Action<StringBuilder> expressionBuilder);

	/// <summary>
	///     Verifies, if the expectations are met.
	/// </summary>
	Task<ConstraintResult> IsMet();

	/// <summary>
	///     Add an OR node, using the <paramref name="textSeparator" />.
	///     Also update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder Or(
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " or ");

	/// <summary>
	///     Add a new <paramref name="expectation" /> that accesses the <paramref name="propertyAccessor" />.
	///     Also update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder Which<TSource, TProperty>(
		PropertyAccessor propertyAccessor,
		Action<That<TProperty>>? expectation,
		Action<StringBuilder> expressionBuilder,
		string andTextSeparator = "",
		string whichTextSeparator = " which ");

	/// <summary>
	///     Add a new <paramref name="expectation" /> that accesses the <paramref name="propertyAccessor" /> and casts from
	///     <typeparamref name="TBase" /> to
	///     <typeparamref name="TProperty" />.
	///     Also update the <paramref name="expressionBuilder" />.
	/// </summary>
	IExpectationBuilder WhichCast<TSource, TBase, TProperty>(
		PropertyAccessor propertyAccessor,
		IExpectation<TBase, TProperty> cast,
		Action<That<TProperty>> expectation,
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " which ")
		where TProperty : TBase;

	/// <summary>
	///     Amends the latest expectation with a <paramref name="reason" /> explaining it is needed.
	/// </summary>
	void AddReason(string reason);
}
