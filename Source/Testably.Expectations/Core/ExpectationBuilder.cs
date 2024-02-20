using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core.Nodes;
[assembly: InternalsVisibleTo("Testably.Expectations.Tests")]

namespace Testably.Expectations.Core;


[StackTraceHidden]
internal class ExpectationBuilder : IExpectationBuilder
{
	internal class Tree
	{
		private class TreeNode
		{
			public Node Node { get; set; } = Node.None;
			public TreeNode? Parent { get; set; }
			public int Precedence { get; set; }

			/// <inheritdoc />
			public override string ToString()
				=> $"{Parent} -> {Node}";
		}

		private TreeNode _current;
		private Action<Node>? _setExpectationNode;

		public Node GetRoot()
		{
			var current = _current;
			while (current.Parent != null)
			{
				current = current.Parent;
			}

			return current.Node;
		}

		public Tree()
		{
			_current = new TreeNode();
			_setExpectationNode = n => _current.Node = n;
		}

		public void AddExpectation(IExpectation expectation)
		{
			if (_setExpectationNode == null)
			{
				throw new InvalidOperationException(
					"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
			}
			var node = new ExpectationNode(expectation);
			_setExpectationNode.Invoke(node);
			_setExpectationNode = null;
		}

		public bool TryAddCombination(Func<Node, CombinationNode> nodeGenerator, int precedence)
		{
			if (_setExpectationNode != null)
			{
				return false;
			}

			var current = _current;
			do
			{
				if (current.Node is CombinationNode parentCombinationNode && current.Precedence < precedence)
				{
					var newCombinationNode = nodeGenerator(parentCombinationNode.Right);
					parentCombinationNode.Right = newCombinationNode;
					_current = new TreeNode()
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

			var combinationNode = nodeGenerator(_current.Node);
			_current = new TreeNode
			{
				Node = combinationNode,
				Parent = _current.Parent,
				Precedence = precedence
			};
			_setExpectationNode = n => combinationNode.Right = n;
			return true;
		}

		public void AddCombination(Func<Node, CombinationNode> nodeGenerator, int precedence)
		{
			if (!TryAddCombination(nodeGenerator, precedence))
			{
				throw new InvalidOperationException(
					"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
			}
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
				var manipulationNode2 = nodeGenerator(combinationNode.Right);
				combinationNode.Right = manipulationNode2;
				_setExpectationNode = n => manipulationNode2.Inner = n;
				return;
			}


			if (_current.Node is ManipulationNode manipulationNode4)
			{
				var manipulationNode3 = nodeGenerator(manipulationNode4.Inner);
				manipulationNode4.Inner = manipulationNode3;
				_setExpectationNode = n => manipulationNode3.Inner = n;
				return;
			}

			var manipulationNode = nodeGenerator(_current.Node);
			_current = new TreeNode
			{
				Node = manipulationNode,
				Parent = _current.Parent
			};
			_setExpectationNode = n => manipulationNode.Inner = n;
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
	}
	private Tree _tree = new();

	#region IExpectationBuilder Members

	/// <inheritdoc />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		_tree.AddExpectation(expectation);
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation)
	{
		_tree.AddManipulation(n => new CastNode<T1, T2>(expectation, n));
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder And()
	{
		_tree.AddCombination(n => new AndNode(n, Node.None), 5);
		return this;
	}

	public ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		return _tree.GetRoot().IsMetBy(actual);
	}

	/// <inheritdoc />
	public IExpectationBuilder Not()
	{
		_tree.AddManipulation(n => new NotNode(n));
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder Or()
	{
		_tree.AddCombination(n => new OrNode(n, Node.None), 4);
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder Which<TSource, TProperty>(PropertyAccessor propertyAccessor,
		IExpectation<TProperty> expectation)
	{
		_tree.TryAddCombination(n => new AndNode(n, Node.None), 5);
		_tree.AddManipulation(n => new WhichNode<TSource, TProperty>(propertyAccessor, Node.None));
		_tree.AddExpectation(expectation);

		return this;
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
	{
		return _tree.ToString();
	}
}
