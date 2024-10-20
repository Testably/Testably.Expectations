﻿using System.Threading.Tasks;

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
	public override async Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		ConstraintResult? result = await TryMeet(Expectation, value);
		if (Inner != None && result is ConstraintResult.Success<T2> success)
		{
			return await Inner.IsMetBy(new SourceValue<T2>(success.Value, value.Exception));
		}

		return result;
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation.ToString() ?? "<EMPTY EXPECTATION>";
}
