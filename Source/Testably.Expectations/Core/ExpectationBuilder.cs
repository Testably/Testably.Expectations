﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Core.TimeSystem;

namespace Testably.Expectations.Core;

/// <summary>
///     The builder for collecting all expectations.
/// </summary>
[DebuggerDisplay("{_tree}")]
public abstract class ExpectationBuilder
{
	internal string Subject { get; }

	private CancellationToken? _cancellationToken;

	private Node _node = new ExpectationNode();

	private ITimeSystem? _timeSystem;

	private Node? _whichNode;
	//private readonly Tree _tree = new();

	/// <summary>
	///     Initializes the <see cref="ExpectationBuilder" /> with the <paramref name="subjectExpression" />
	///     for the statement builder.
	/// </summary>
	protected ExpectationBuilder(string subjectExpression)
	{
		Subject = subjectExpression;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IValueConstraint<TValue> constraint)
	{
		_node.AddConstraint(constraint);
		return this;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value asynchronously
	///     using the <see cref="IEvaluationContext" />.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IAsyncContextConstraint<TValue> constraint)
	{
		_node.AddConstraint(constraint);
		return this;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value
	///     using the <see cref="IEvaluationContext" />.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IContextConstraint<TValue> constraint)
	{
		_node.AddConstraint(constraint);
		return this;
	}

	/// <summary>
	///     Adds the <paramref name="constraint" /> which verifies the underlying value asynchronously.
	/// </summary>
	public ExpectationBuilder AddConstraint<TValue>(IAsyncConstraint<TValue> constraint)
	{
		_node.AddConstraint(constraint);
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
		return new PropertyExpectationBuilder<TSource, TTarget>((a, s, c) =>
		{
			if (s is not null)
			{
				And(" ");
				_node.AddConstraint(s);
			}
			
			_node.AddMapping(null, propertyAccessor, expectationTextGenerator);
			if (c is not null)
			{
				_node.AddConstraint(c);
			}

			a?.Invoke(this);
			return this;
		});
	}

	/// <summary>
	///     Adds a <paramref name="cancellationToken" /> to be used by the constraints.
	/// </summary>
	public void WithCancellation(CancellationToken cancellationToken)
	{
		_cancellationToken = cancellationToken;
	}

	/// <summary>
	///     Adds a <paramref name="reason" /> to the current expectation constraint.
	/// </summary>
	internal void AddReason(string reason)
	{
		BecauseReason becauseReason = new(reason);
		_node.SetReason(becauseReason);
	}

	internal ExpectationBuilder And(string textSeparator = " and ")
	{
		if (_node is AndNode andNode)
		{
			andNode.AddNode(new ExpectationNode(), textSeparator);
		}
		else if (_node is OrNode orNode)
		{
			AndNode newNode = new AndNode(orNode.Current);
			newNode.AddNode(new ExpectationNode(), textSeparator);
			orNode.Current = newNode;
		}
		else
		{
			AndNode newNode = new AndNode(_node);
			newNode.AddNode(new ExpectationNode(), textSeparator);
			_node = newNode;
		}

		return this;
	}

	/// <summary>
	///     Specifies a global mapping for the value to test.
	/// </summary>
	/// <remarks>
	///     Intended for mapping the <see cref="DelegateValue{TValue}" /> to an exception.
	/// </remarks>
	internal ExpectationBuilder ForWhich<TSource, TTarget>(
		Func<TSource, TTarget?> whichAccessor)
	{
		_whichNode = new WhichNode<TSource, TTarget>(whichAccessor);
		return this;
	}

	/// <summary>
	///     Creates the exception message from the <paramref name="failure" />.
	/// </summary>
	internal string FromFailure(string subject, ConstraintResult.Failure failure)
		=> $"""
		    Expected {subject} to
		    {failure.ExpectationText},
		    but {failure.ResultText}
		    """;

	internal Task<ConstraintResult> IsMet()
	{
		EvaluationContext.EvaluationContext context = new();
		if (_whichNode != null)
		{
			_whichNode.AddNode(_node);
			_node = _whichNode;
		}

		return IsMet(_node, context, _timeSystem ?? RealTimeSystem.Instance,
			_cancellationToken ?? CancellationToken.None);
	}

	internal abstract Task<ConstraintResult> IsMet(
		Node rootNode,
		EvaluationContext.EvaluationContext context,
		ITimeSystem timeSystem,
		CancellationToken cancellationToken);

	// TODO VAB: do we need the textseparator?
	internal void Or(string textSeparator = " or ")
	{
		if (_node is OrNode orNode)
		{
			orNode.AddNode(new ExpectationNode(), textSeparator);
		}

		OrNode newNode = new OrNode(_node);
		newNode.AddNode(new ExpectationNode(), textSeparator);
		_node = newNode;
	}

	/// <summary>
	///     Specifies a <see cref="ITimeSystem" /> to use for the expectation.
	/// </summary>
	internal void UseTimeSystem(ITimeSystem timeSystem)
	{
		_timeSystem = timeSystem;
	}

	/// <summary>
	///     Helper class to specify constraints on the selected <typeparamref name="TProperty" />.
	/// </summary>
	public class PropertyExpectationBuilder<TSource, TProperty>
	{
		private readonly
			Func<Action<ExpectationBuilder>, IValueConstraint<TSource>?, IValueConstraint<TProperty>?, ExpectationBuilder>
			_callback;

		private IValueConstraint<TSource>? _sourceConstraint = null;
		private readonly IValueConstraint<TProperty>? _constraint = null;

		internal PropertyExpectationBuilder(
			Func<Action<ExpectationBuilder>, IValueConstraint<TSource>?, IValueConstraint<TProperty>?, ExpectationBuilder>
				callback)
		{
			_callback = callback;
		}

		/// <summary>
		///     Add expectations for the current <typeparamref name="TProperty" />.
		/// </summary>
		public ExpectationBuilder AddExpectations(Action<ExpectationBuilder> expectation)
		{
			return _callback(expectation, _sourceConstraint, _constraint);
		}

		/// <summary>
		///     Add a validation constraint for the current <typeparamref name="TProperty" />,
		///     that it is of type <typeparamref name="TSource" />.
		/// </summary>
		public PropertyExpectationBuilder<TSource, TProperty> Validate(
			IValueConstraint<TSource> constraint)
		{
			_sourceConstraint = constraint;
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

	internal ExpectationBuilder(
		IValueSource<TValue> subjectSource,
		string subjectExpression)
		: base(subjectExpression)
	{
		_subjectSource = subjectSource;
	}

	/// <inheritdoc />
	internal override async Task<ConstraintResult> IsMet(
		Node rootNode,
		EvaluationContext.EvaluationContext context,
		ITimeSystem timeSystem,
		CancellationToken cancellationToken)
	{
		TValue? data = await _subjectSource.GetValue(timeSystem, cancellationToken);
		return await rootNode.IsMetBy(data, context, cancellationToken);
	}
}
