using System;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Nodes;

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

	public void AddNode(Node node)
	{
		if (_setExpectationNode == null)
		{
			throw new InvalidOperationException(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
		}

		_setExpectationNode.Invoke(node);
		_setExpectationNode = null;
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
