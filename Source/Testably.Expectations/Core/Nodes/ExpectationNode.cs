using System;

namespace Testably.Expectations.Core.Nodes;

internal class ExpectationNode : Node
{
	public IExpectation Expectation { get; }

	public ExpectationNode(IExpectation expectation)
	{
		Expectation = expectation;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(SourceValue<TExpectation> value)
		where TExpectation : default
	{
		if (Expectation is IDelegateExpectation<TExpectation> exceptionExpectation)
		{
			return exceptionExpectation.IsMetBy(value);
		}

		if (Expectation is IExpectation<TExpectation?> typedExpectation)
		{
			return typedExpectation.IsMetBy(value.Value);
		}

		if (Expectation is IDelegateExpectation exceptionExpectationWithoutValue)
		{
			return exceptionExpectationWithoutValue.IsMetBy(value.Exception);
		}


		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {value.Value}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation?.ToString() ?? "<EMPTY EXPECTATION>";
}
