using System;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Nodes;

namespace Testably.Expectations.Core;


/// <summary>
///     The builder for collecting all expectations.
/// </summary>
public abstract class ExpectationBuilder
{
	/// <summary>
	///     The builder for the failure message.
	/// </summary>
	public IFailureMessageBuilder FailureMessageBuilder => _failureMessageBuilder;

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

	/// <inheritdoc />
	public override string ToString()
	{
		return _tree.ToString();
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
				: new LegacyDeferredNode<TProperty, TThatProperty>(expectation, thatPropertyFactory),
			null));

		return this;
	}

	public PropertyExpectationBuilder<TSource, TTarget> ForProperty<TSource, TTarget>(
		PropertyAccessor<TSource, TTarget?> propertyAccessor,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null)
	{
		return new PropertyExpectationBuilder<TSource, TTarget>((a, c) =>
		{
			_tree.TryAddCombination(n => new AndNode(n, Node.None, ""), 5);
			_tree.AddManipulation(_ => new WhichNode<TSource, TTarget>(
				propertyAccessor,
				c == null ? new DeferredNode<TTarget>(a) : new AndNode(new ExpectationNode(c), new DeferredNode<TTarget>(a), ""),
				expectationTextGenerator));
			return this;
		});
	}

	public class PropertyExpectationBuilder<TSource, TProperty>
	{
		private readonly Func<Action<ExpectationBuilder>, IValueConstraint<TProperty>?, ExpectationBuilder> _callback;
		private IValueConstraint<TProperty>? _constraint;

		internal PropertyExpectationBuilder(Func<Action<ExpectationBuilder>, IValueConstraint<TProperty>?, ExpectationBuilder> callback)
		{
			_callback = callback;
		}

		public PropertyExpectationBuilder<TSource, TProperty> Cast<TTarget>(ICastConstraint<TProperty, TTarget> constraint)
		{
			_constraint = constraint;
			return this;
		}

		public ExpectationBuilder Add(Action<ExpectationBuilder> expectation)
		{
			return _callback(expectation, _constraint);
		}
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
			cast, new LegacyDeferredNode<TProperty, TThatProperty>(expectation, thatPropertyFactory),
			textSeparator));

		return this;
	}

	internal ExpectationBuilder And(Action<StringBuilder> expressionBuilder,
		string textSeparator = " and ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new AndNode(n, Node.None, textSeparator), 5);
		return this;
	}

	internal Task<ConstraintResult> IsMet()
	{
		EvaluationContext.EvaluationContext context = new();
		Node rootNode = _tree.GetRoot();
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
}
