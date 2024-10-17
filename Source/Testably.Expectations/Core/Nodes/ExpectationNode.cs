using System;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal class ExpectationNode : Node
{
	public IExpectation Expectation { get; }

	public ExpectationNode(IExpectation expectation)
	{
		Expectation = expectation;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		if (Expectation is IDelegateExpectation<TValue> exceptionExpectation)
		{
			return exceptionExpectation.IsMetBy(value);
		}

		if (Expectation is IDelegateExpectation<DelegateSource.WithoutValue> delegateWithoutValueExpectation)
		{
			return delegateWithoutValueExpectation.IsMetBy(new SourceValue<DelegateSource.WithoutValue>(DelegateSource.WithoutValue.Instance, value.Exception));
		}

		if (Expectation is IExpectation<TValue?> nullableTypedExpectation)
		{
			return nullableTypedExpectation.IsMetBy(value.Value);
		}

		if (Expectation is IDelegateExpectation exceptionExpectationWithoutValue)
		{
			return exceptionExpectationWithoutValue.IsMetBy(value.Exception);
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TValue).Name} {value.Value}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation?.ToString() ?? "<EMPTY EXPECTATION>";
}
