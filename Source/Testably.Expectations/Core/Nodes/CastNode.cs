using System;
using Testably.Expectations.Core.Sources;
using Testably.Expectations.Expectations;

namespace Testably.Expectations.Core.Nodes;

internal class CastNode<T1, T2> : ManipulationNode
{
	public IExpectation<T1, T2> Expectation { get; }
	public override Node Inner { get; set; }

	public CastNode(IExpectation<T1, T2> expectation, Node inner)
	{
		Expectation = expectation;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		ExpectationResult result = TryMeet(Expectation, value);
		if (Inner != None && result is ExpectationResult.Success<T2> success)
		{
			return Inner.IsMetBy(new SourceValue<T2>(success.Value, value.Exception));
		}

		return result;
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation.ToString() ?? "<EMPTY EXPECTATION>";
}
