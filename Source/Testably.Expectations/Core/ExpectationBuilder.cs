﻿using System;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core;

/// <summary>
///     The builder for collecting all expectations.
/// </summary>
public abstract class ExpectationBuilder
{
	/// <summary>
	///     The builder for the failure message.
	/// </summary>
	internal IFailureMessageBuilder FailureMessageBuilder => _failureMessageBuilder;

	private readonly FailureMessageBuilder _failureMessageBuilder;
	private readonly Tree _tree = new();

	/// <summary>
	///     Initializes the <see cref="ExpectationBuilder" /> with the <paramref name="subjectExpression" />
	///     for the statement builder.
	/// </summary>
	protected ExpectationBuilder(string subjectExpression)
	{
		_failureMessageBuilder = new FailureMessageBuilder(subjectExpression);
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IValueConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value
	///     using the <see cref="IEvaluationContext" />.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IContextConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value asynchronously.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IAsyncConstraint<TValue> constraint)
	{
		_tree.AddExpectation(constraint);
		return this;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value
	///     and returns a different <typeparamref name="TTarget" /> for subsequent constraints.
	/// </summary>
	public ExpectationBuilder AddConstraint<TSource, TTarget>(
		ICastConstraint<TSource, TTarget> constraint)
	{
		_tree.AddManipulation(n => new CastNode<TSource, TTarget>(constraint, n));
		return this;
	}

	/// <summary>
	///     Adds a <paramref name="reason" /> to the current expectation constraint.
	/// </summary>
	public void AddReason(string reason)
	{
		BecauseReason becauseReason = new(reason);
		_tree.GetCurrent().SetReason(becauseReason);
	}

	/// <summary>
	///     Appends the <paramref name="value" /> to the statement builder.
	/// </summary>
	public ExpectationBuilder AppendStatement(string value)
	{
		_failureMessageBuilder.ExpressionBuilder.Append(value);
		return this;
	}

	/// <summary>
	///     Specifies a constraint that applies to the property selected
	///     by the <paramref name="propertyAccessor" />.
	/// </summary>
	public PropertyExpectationBuilder<TSource, TTarget> ForProperty<TSource, TTarget>(
		PropertyAccessor<TSource, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null)
	{
		return new PropertyExpectationBuilder<TSource, TTarget>((a, c) =>
		{
			_tree.TryAddCombination(n => new AndNode(n, Node.None, ""), 5);
			_tree.AddManipulation(_ => new WhichNode<TSource, TTarget>(
				propertyAccessor,
				c == null
					? new DeferredNode<TTarget>(a)
					: new AndNode(new ExpectationNode(c), new DeferredNode<TTarget>(a), ""),
				expectationTextGenerator));
			return this;
		});
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return _tree.ToString();
	}

	internal void And(Action<StringBuilder> expressionBuilder,
		string textSeparator = " and ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new AndNode(n, Node.None, textSeparator), 5);
	}

	internal Task<ConstraintResult> IsMet()
	{
		EvaluationContext.EvaluationContext context = new();
		Node rootNode = _tree.GetRoot();
		return IsMet(context, rootNode);
	}

	internal abstract Task<ConstraintResult> IsMet(
		EvaluationContext.EvaluationContext context, Node rootNode);

	internal void Or(Action<StringBuilder> expressionBuilder,
		string textSeparator = " or ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new OrNode(n, Node.None, textSeparator), 4);
	}

	/// <summary>
	///     Helper class to specify constraints on the selected <typeparamref name="TProperty" />.
	/// </summary>
	public class PropertyExpectationBuilder<TSource, TProperty>
	{
		private readonly
			Func<Action<ExpectationBuilder>, IValueConstraint<TProperty>?, ExpectationBuilder>
			_callback;

		private IValueConstraint<TProperty>? _constraint;

		internal PropertyExpectationBuilder(
			Func<Action<ExpectationBuilder>, IValueConstraint<TProperty>?, ExpectationBuilder>
				callback)
		{
			_callback = callback;
		}

		/// <summary>
		///     Add expectations for the current <typeparamref name="TProperty" />.
		/// </summary>
		public ExpectationBuilder AddExpectations(Action<ExpectationBuilder> expectation)
		{
			return _callback(expectation, _constraint);
		}

		/// <summary>
		///     Add a validation constraint for the current <typeparamref name="TProperty" />,
		///     that it is of type <typeparamref name="TTarget" />.
		/// </summary>
		public PropertyExpectationBuilder<TSource, TProperty> Validate<TTarget>(
			ICastConstraint<TProperty, TTarget> constraint)
		{
			_constraint = constraint;
			return this;
		}
	}
}

internal class ExpectationBuilder<TValue> : ExpectationBuilder
{
	/// <summary>
	///     The subject.
	/// </summary>
	private readonly IValueSource<TValue> _subjectSource;

	internal ExpectationBuilder(IValueSource<TValue> subjectSource, string subjectExpression) :
		base(
			subjectExpression)
	{
		_subjectSource = subjectSource;
	}

	/// <inheritdoc />
	internal override async Task<ConstraintResult> IsMet(
		EvaluationContext.EvaluationContext context, Node rootNode)
	{
		TValue? data = await _subjectSource.GetValue();
		return await rootNode.IsMetBy(data, context);
	}
}
