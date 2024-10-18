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
		=> TryMeet(Expectation, value);

	/// <inheritdoc />
	public override string ToString()
		=> Expectation?.ToString() ?? "<EMPTY EXPECTATION>";
}
