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
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation? actual, Exception? exception)
		where TExpectation : default
	{
		if (Expectation is IDelegateExpectation<TExpectation> exceptionExpectation)
		{
			return exceptionExpectation.IsMetBy(actual, exception);
		}

		if (Expectation is IExpectation<TExpectation?> typedExpectation)
		{
			return typedExpectation.IsMetBy(actual);
		}
		if (Expectation is IDelegateExpectation exceptionExpectationWithoutValue)
		{
			return exceptionExpectationWithoutValue.IsMetBy(exception);
		}


		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {actual}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation?.ToString() ?? "<EMPTY EXPECTATION>";
}
