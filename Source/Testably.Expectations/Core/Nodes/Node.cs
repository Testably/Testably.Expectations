using System;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	public static Node None { get; } = new NoneNode();

	public abstract ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value);

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
			where TValue : default
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}

	protected ExpectationResult TryMeet<TValue>(IExpectation expectation, SourceValue<TValue> value)
	{
		if (expectation is IExpectation<TValue?> typedExpectation)
		{
			return typedExpectation.IsMetBy(value.Value);
		}

		if (expectation is IDelegateExpectation<TValue> typedDelegateExpectation)
		{
			return typedDelegateExpectation.IsMetBy(value);
		}

		if (expectation is IDelegateExpectation<DelegateSource.NoValue> delegateExpectation)
		{
			return delegateExpectation.IsMetBy(new SourceValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance, value.Exception));
		}

		throw new InvalidOperationException(
			$"The expectation node does not support {typeof(TValue).Name} {value.Value}");
	}
}
