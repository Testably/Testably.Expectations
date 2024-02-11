using System;
using System.Diagnostics;
using Testably.Expectations.Core.Nodes;

namespace Testably.Expectations.Core;

[StackTraceHidden]
internal class ExpectationBuilder : IExpectationBuilder
{
	private Func<Node>? _getCurrent;
	private Node _root = Node.None;
	private Action<Node>? _setCurrent;

	public ExpectationBuilder()
	{
		_setCurrent = n => _root = n;
		_getCurrent = () => _root;
	}

	#region IExpectationBuilder Members

	/// <inheritdoc />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		if (_setCurrent != null)
		{
			_setCurrent(new ExpectationNode(expectation));
			_setCurrent = null;
			_getCurrent = null;
		}
		else
		{
			throw new InvalidOperationException(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
		}

		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder AddCast<T1, T2>(IExpectation<T1, T2> expectation)
	{
		if (_setCurrent != null && _getCurrent != null)
		{
			CastNode<T1, T2> castNode = new CastNode<T1, T2>(expectation, _getCurrent());
			_setCurrent(castNode);
			_setCurrent = n => castNode.Inner = n;
			_getCurrent = () => castNode.Inner;
		}
		else
		{
			throw new InvalidOperationException(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
		}

		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder And()
	{
		if (_root == Node.None)
		{
			throw new InvalidOperationException(
				"You have to specify an expectation before starting a combination with `And()`.");
		}

		if (_root is OrNode orNode)
		{
			AndNode andNode = new AndNode(orNode.Right, Node.None);
			orNode.Right = andNode;
			_setCurrent = n => andNode.Right = n;
			_getCurrent = () => andNode.Right;
		}
		else
		{
			AndNode andNode = new AndNode(_root, Node.None);
			_root = andNode;
			_setCurrent = n => andNode.Right = n;
			_getCurrent = () => andNode.Right;
		}

		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		return _root.ApplyTo(actual);
	}

	/// <inheritdoc />
	public IExpectationBuilder Not()
	{
		if (_setCurrent != null && _getCurrent != null)
		{
			NotNode notNode = new NotNode(_getCurrent());
			_setCurrent(notNode);
			_setCurrent = n => notNode.Inner = n;
			_getCurrent = () => notNode.Inner;
		}
		else
		{
			throw new InvalidOperationException(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
		}

		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder Or()
	{
		if (_root == Node.None)
		{
			throw new InvalidOperationException(
				"You have to specify an expectation before starting a combination with `Or()`.");
		}

		OrNode orNode = new OrNode(_root, Node.None);
		_root = orNode;
		_setCurrent = n => orNode.Right = n;
		_getCurrent = () => orNode.Right;
		return this;
	}

	/// <inheritdoc />
	public IExpectationBuilder Which<TSource, TProperty>(string property,
		IExpectation<TProperty> expectation)
	{
		if (_setCurrent == null && _getCurrent == null)
		{
			And();
		}

		if (_setCurrent != null)
		{
			_setCurrent(
				new WhichNode<TProperty>(property, new ExpectationNode(expectation)));
			_setCurrent = null;
			_getCurrent = null;
		}
		else
		{
			throw new InvalidOperationException(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
		}

		return this;
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
	{
		string s = _root.ToString() ?? "{}";
		if (s.StartsWith('(') && s.EndsWith(')'))
		{
			return s.Substring(1, s.Length - 2);
		}

		return s;
	}
}
