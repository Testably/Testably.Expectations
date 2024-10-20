﻿using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	private BecauseReason? _reason;
	public static Node None { get; } = new NoneNode();

	public abstract Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value);

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";

	protected Task<ConstraintResult> TryMeet<TValue>(IConstraint constraint,
		SourceValue<TValue> value)
	{
		if (constraint is IConstraint<TValue?> typedExpectation)
		{
			var result = typedExpectation.IsMetBy(value.Value);
			result = _reason?.ApplyTo(result) ?? result;
			return Task.FromResult(result);
		}

		if (constraint is IDelegateConstraint<TValue> typedDelegateExpectation)
		{
			var result = typedDelegateExpectation.IsMetBy(value);
			result = _reason?.ApplyTo(result) ?? result;
			return Task.FromResult(result);
		}

		if (constraint is IDelegateConstraint<DelegateSource.NoValue> delegateExpectation)
		{
			var result = delegateExpectation.IsMetBy(
				new SourceValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance,
					value.Exception));
			result = _reason?.ApplyTo(result) ?? result;
			return Task.FromResult(result);
		}

		throw new InvalidOperationException(
			$"The expectation node does not support {typeof(TValue).Name} {value.Value}");
	}

	public virtual void SetReason(BecauseReason reason)
	{
		_reason = reason;
	}

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value)
			where TValue : default
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}
}
