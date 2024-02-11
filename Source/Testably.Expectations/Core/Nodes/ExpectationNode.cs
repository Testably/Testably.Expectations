using System;

namespace Testably.Expectations.Core.Nodes;

internal class ExpectationNode : Node
{
	public IExpectation? Expectation { get; private set; }

	public ExpectationNode(IExpectation expectation)
	{
		Expectation = expectation;
	}

	public ExpectationNode()
	{
	}

	/// <inheritdoc />
	public override ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		if (Expectation is IExpectation<TExpectation> typedExpectation)
		{
			return typedExpectation.IsMetBy(actual);
		}

		if (Expectation is null)
		{
			throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {actual}");
	}

	public void SetExpectation(IExpectation expectation)
	{
		Expectation = expectation;
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation?.ToString() ?? "<EMPTY EXPECTATION>";
}
