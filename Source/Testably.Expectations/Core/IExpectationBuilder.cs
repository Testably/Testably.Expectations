using System;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Nodes;

namespace Testably.Expectations.Core;

/// <summary>
///     The builder for collecting all expectations.
/// </summary>
public abstract class ExpectationBuilder
{
	private readonly FailureMessageBuilder _failureMessageBuilder;
	private readonly Tree _tree = new();

	protected ExpectationBuilder(string subjectExpression)
	{
		_failureMessageBuilder = new FailureMessageBuilder(subjectExpression);
	}

	/// <summary>
	///     The builder for the failure message.
	/// </summary>
	public IFailureMessageBuilder FailureMessageBuilder => _failureMessageBuilder;

	public ExpectationBuilder AddConstraint<TValue>(IValueConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}
	
	public ExpectationBuilder AddConstraint<TValue>(IContextConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}

	public ExpectationBuilder AddConstraint<TValue>(IAsyncConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}
	public ExpectationBuilder AddConstraint<TValue>(IComplexConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}
	public ExpectationBuilder AddCast<T1, T2>(ICastConstraint<T1, T2> castConstraint,
		Action<StringBuilder> expressionBuilder)
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddManipulation(n => new CastNode<T1, T2>(castConstraint, n));
		return this;
	}

	public void AddReason(string reason)
	{
		BecauseReason becauseReason = new BecauseReason(reason);
		_tree.GetCurrent().SetReason(becauseReason);
	}

	internal ExpectationBuilder And(Action<StringBuilder> expressionBuilder,
		string textSeparator = " and ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new AndNode(n, Node.None, textSeparator), 5);
		return this;
	}

	public ExpectationBuilder AppendStatement(string value)
	{
		_failureMessageBuilder.ExpressionBuilder.Append(value);
		return this;
	}

	internal Task<ConstraintResult> IsMet()
	{
		EvaluationContext.EvaluationContext context = new();
		var rootNode = _tree.GetRoot();
		return IsMet(context, rootNode);
	}

	internal abstract Task<ConstraintResult> IsMet(
		EvaluationContext.EvaluationContext context, Node rootNode);

	internal ExpectationBuilder Or(Action<StringBuilder> expressionBuilder,
		string textSeparator = " or ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new OrNode(n, Node.None, textSeparator), 4);
		return this;
	}

	public ExpectationBuilder Which<TSource, TProperty, TThatProperty>(
		PropertyAccessor propertyAccessor,
		Action<TThatProperty>? expectation,
		Func<ExpectationBuilder, TThatProperty> thatPropertyFactory,
		Action<StringBuilder> expressionBuilder,
		string andTextSeparator = "",
		string whichTextSeparator = " which ",
		string whichPropertyTextSeparator = "")
		where TThatProperty : IThat<TProperty>
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.TryAddCombination(n => new AndNode(n, Node.None, andTextSeparator), 5);
		_tree.AddManipulation(_ => new WhichNode<TSource, TProperty>(
			propertyAccessor,
			expectation == null
				? Node.None
				: new DeferredNode<TProperty, TThatProperty>(expectation, thatPropertyFactory),
			whichTextSeparator,
			whichPropertyTextSeparator));

		return this;
	}

	public ExpectationBuilder WhichCast<TSource, TBase, TProperty, TThatProperty>(
		PropertyAccessor propertyAccessor,
		ICastConstraint<TBase, TProperty> cast,
		Action<TThatProperty> expectation,
		Func<ExpectationBuilder, TThatProperty> thatPropertyFactory,
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " which ")
		where TThatProperty : IThat<TProperty>
		where TProperty : TBase
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.TryAddCombination(n => new AndNode(n, Node.None, ""), 5);
		_tree.AddManipulation(_ => new WhichCastNode<TSource, TBase, TProperty>(propertyAccessor,
			cast, new DeferredNode<TProperty, TThatProperty>(expectation, thatPropertyFactory), textSeparator));

		return this;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return _tree.ToString();
	}
}
