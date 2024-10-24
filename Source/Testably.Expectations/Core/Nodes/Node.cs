using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal class EvaluationContext : IEvaluationContext
{
	private object? _value;

	/// <inheritdoc />
	public void SetValue<T>(T value)
	{
		_value = value;
	}

	/// <inheritdoc />
	public T? GetValue<T>()
	{
		if (_value is T value)
		{
			return value;
		}

		return default;
	}
}

public interface IEvaluationContext
{
	void SetValue<T>(T value);
	T? GetValue<T>();
}

public static class EvaluationContextExtensions
{
	public static IEnumerable<TItem> UseMaterializedEnumerable<TItem, TCollection>(
		this IEvaluationContext context, TCollection collection)
	where TCollection : IEnumerable<TItem>
	{
		var existingValue = context.GetValue<IEnumerable<TItem>>();
		if (existingValue != null)
		{
			return existingValue;
		}

		var materializedEnumerable = MaterializingEnumerable<TItem>.Wrap(collection);
		context.SetValue(materializedEnumerable);
		return materializedEnumerable;
	}
}

internal abstract class Node
{
	protected BecauseReason? Reason { get; private set; }
	public static Node None { get; } = new NoneNode();

	public abstract Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value, IEvaluationContext context);

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";

	public virtual void SetReason(BecauseReason reason)
	{
		Reason = reason;
	}

	protected static async Task<ConstraintResult> TryMeet<TValue>(IConstraint constraint,
		SourceValue<TValue> value,
		IEvaluationContext context,
		BecauseReason? reason)
	{
		if (constraint is IConstraint<TValue?> valueConstraint)
		{
			var result = valueConstraint.IsMetBy(value.Value);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (constraint is IContextConstraint<TValue?> contextConstraint)
		{
			var result = contextConstraint.IsMetBy(value.Value, context);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (constraint is IAsyncConstraint<TValue?> asyncConstraint)
		{
			var result = await asyncConstraint.IsMetBy(value.Value);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (constraint is IDelegateConstraint<TValue> delegateValueConstraint)
		{
			var result = delegateValueConstraint.IsMetBy(value);
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		if (constraint is IDelegateConstraint<DelegateSource.NoValue> delegateConstraint)
		{
			var result = delegateConstraint.IsMetBy(
				new SourceValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance,
					value.Exception));
			result = reason?.ApplyTo(result) ?? result;
			return result;
		}

		throw new InvalidOperationException(
			$"The expectation node does not support {typeof(TValue).Name} {value.Value}");
	}
	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value, IEvaluationContext context)
			where TValue : default
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}
}
