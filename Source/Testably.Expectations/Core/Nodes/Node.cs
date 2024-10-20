using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	public static Node None { get; } = new NoneNode();

	public abstract Task<ExpectationResult> IsMetBy<TValue>(SourceValue<TValue> value);

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";

	protected Task<ExpectationResult> TryMeet<TValue>(IExpectation expectation,
		SourceValue<TValue> value)
	{
		if (expectation is IExpectation<TValue?> typedExpectation)
		{
			return Task.FromResult(typedExpectation.IsMetBy(value.Value));
		}

		if (expectation is IDelegateExpectation<TValue> typedDelegateExpectation)
		{
			return Task.FromResult(typedDelegateExpectation.IsMetBy(value));
		}

		if (expectation is IDelegateExpectation<DelegateSource.NoValue> delegateExpectation)
		{
			return Task.FromResult(delegateExpectation.IsMetBy(
				new SourceValue<DelegateSource.NoValue>(DelegateSource.NoValue.Instance,
					value.Exception)));
		}

		throw new InvalidOperationException(
			$"The expectation node does not support {typeof(TValue).Name} {value.Value}");
	}

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override Task<ExpectationResult> IsMetBy<TValue>(SourceValue<TValue> value)
			where TValue : default
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}
}
