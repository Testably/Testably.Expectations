using System;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core;

internal class ExpectationBuilder<TValue> : IExpectationBuilder
{
	private readonly FailureMessageBuilder _failureMessageBuilder;

	/// <summary>
	///     The subject.
	/// </summary>
	private readonly IValueSource<TValue> _subjectSource;

	private readonly Tree _tree = new();

	public ExpectationBuilder(TValue subject, string subjectExpression)
	{
		_failureMessageBuilder = new FailureMessageBuilder(subjectExpression);
		_subjectSource = new ValueSource<TValue>(subject);
	}

	public ExpectationBuilder(IValueSource<TValue> subjectSource, string subjectExpression)
	{
		_failureMessageBuilder = new FailureMessageBuilder(subjectExpression);
		_subjectSource = subjectSource;
	}

	#region IExpectationBuilder Members

	public IFailureMessageBuilder FailureMessageBuilder => _failureMessageBuilder;

	/// <inheritdoc />
	public IExpectationBuilder Add(IConstraint constraint,
		Action<StringBuilder> expressionBuilder)
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddExpectation(constraint);
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder AddCast<T1, T2>(IConstraint<T1, T2> constraint,
		Action<StringBuilder> expressionBuilder)
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddManipulation(n => new CastNode<T1, T2>(constraint, n));
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder And(Action<StringBuilder> expressionBuilder,
		string textSeparator = " and ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new AndNode(n, Node.None, textSeparator), 5);
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder AppendExpression(Action<StringBuilder> expressionBuilder)
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		return this;
	}

	public async Task<ConstraintResult> IsMet()
	{
		var context = new EvaluationContext();
		SourceValue<TValue> data = await _subjectSource.GetValue();
		return await _tree.GetRoot().IsMetBy(data, context);
	}

	/// <inheritdoc />
	public IExpectationBuilder Or(Action<StringBuilder> expressionBuilder,
		string textSeparator = " and ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.AddCombination(n => new OrNode(n, Node.None, textSeparator), 4);
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		Action<That<TProperty>>? expectation,
		Action<StringBuilder> expressionBuilder,
		string andTextSeparator = "",
		string whichTextSeparator = " which ")
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.TryAddCombination(n => new AndNode(n, Node.None, andTextSeparator), 5);
		_tree.AddManipulation(_ => new WhichNode<TSource, TProperty>(
			propertyAccessor,
			expectation == null
				? Node.None
				: new DeferredNode<TProperty>(expectation),
			whichTextSeparator));

		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder WhichCast<TSource, TBase, TProperty>(
		PropertyAccessor propertyAccessor,
		IConstraint<TBase, TProperty> cast,
		Action<That<TProperty>> expectation,
		Action<StringBuilder> expressionBuilder,
		string textSeparator = " which ") where TProperty : TBase
	{
		expressionBuilder.Invoke(_failureMessageBuilder.ExpressionBuilder);
		_tree.TryAddCombination(n => new AndNode(n, Node.None, ""), 5);
		_tree.AddManipulation(_ => new WhichCastNode<TSource, TBase, TProperty>(propertyAccessor,
			cast, new DeferredNode<TProperty>(expectation), textSeparator));

		return this;
	}

	/// <inheritdoc />
	public void AddReason(string reason)
	{
		var becauseReason = new BecauseReason(reason);
		_tree.GetCurrent().SetReason(becauseReason);
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
	{
		return _tree.ToString();
	}

	internal class Tree
	{
		private TreeNode _current;
		private Action<Node>? _setExpectationNode;

		public Tree()
		{
			_current = new TreeNode();
			_setExpectationNode = n => _current.Node = n;
		}

		public void AddCombination(Func<Node, CombinationNode> nodeGenerator, int precedence)
		{
			if (!TryAddCombination(nodeGenerator, precedence))
			{
				throw new InvalidOperationException(
					"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
			}
		}

		public void AddExpectation(IConstraint constraint)
		{
			if (_setExpectationNode == null)
			{
				throw new InvalidOperationException(
					"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
			}

			ExpectationNode node = new(constraint);
			_setExpectationNode.Invoke(node);
			_setExpectationNode = null;
		}

		public void AddManipulation(Func<Node, ManipulationNode> nodeGenerator)
		{
			if (_setExpectationNode == null)
			{
				throw new InvalidOperationException(
					"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
			}

			if (_current.Node is CombinationNode combinationNode)
			{
				ManipulationNode manipulationNode2 = nodeGenerator(combinationNode.Right);
				combinationNode.Right = manipulationNode2;
				_setExpectationNode = n => manipulationNode2.Inner = n;
				return;
			}

			if (_current.Node is ManipulationNode manipulationNode4)
			{
				ManipulationNode manipulationNode3 = nodeGenerator(manipulationNode4.Inner);
				manipulationNode4.Inner = manipulationNode3;
				_setExpectationNode = n => manipulationNode3.Inner = n;
				return;
			}

			ManipulationNode manipulationNode = nodeGenerator(_current.Node);
			_current = new TreeNode
			{
				Node = manipulationNode,
				Parent = _current.Parent
			};
			_setExpectationNode = n => manipulationNode.Inner = n;
		}

		public Node GetCurrent()
			=> _current.Node;

		public Node GetRoot()
		{
			TreeNode? current = _current;
			while (current.Parent != null)
			{
				current = current.Parent;
			}

			return current.Node;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			string s = GetRoot().ToString();
			if (s.StartsWith('(') && s.EndsWith(')'))
			{
				return s.Substring(1, s.Length - 2);
			}

			return s;
		}

		public bool TryAddCombination(Func<Node, CombinationNode> nodeGenerator, int precedence)
		{
			if (_setExpectationNode != null)
			{
				return false;
			}

			TreeNode? current = _current;
			do
			{
				if (current.Node is CombinationNode parentCombinationNode &&
				    current.Precedence < precedence)
				{
					CombinationNode newCombinationNode =
						nodeGenerator(parentCombinationNode.Right);
					parentCombinationNode.Right = newCombinationNode;
					_current = new TreeNode
					{
						Node = newCombinationNode,
						Parent = current,
						Precedence = precedence
					};
					_setExpectationNode = n => newCombinationNode.Right = n;
					return true;
				}

				current = current.Parent;
			} while (current != null);

			CombinationNode combinationNode = nodeGenerator(_current.Node);
			_current = new TreeNode
			{
				Node = combinationNode,
				Parent = _current.Parent,
				Precedence = precedence
			};
			_setExpectationNode = n => combinationNode.Right = n;
			return true;
		}

		private class TreeNode
		{
			public Node Node { get; set; } = Node.None;
			public TreeNode? Parent { get; set; }
			public int Precedence { get; set; }

			/// <inheritdoc />
			public override string ToString()
				=> $"{Parent} -> {Node}";
		}
	}
}
