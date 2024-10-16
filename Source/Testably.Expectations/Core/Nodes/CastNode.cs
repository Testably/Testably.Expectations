﻿using System;

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
	public override ExpectationResult IsMetBy<TExpectation>(SourceValue<TExpectation> value)
		where TExpectation : default
	{
		if (Expectation is IExpectation<TExpectation?> typedExpectation)
		{
			ExpectationResult result = typedExpectation.IsMetBy(value.Value);
			if (Inner != None && result is ExpectationResult.Success<T2> success)
			{
				return Inner.IsMetBy(new SourceValue<T2>(success.Value, value.Exception));
			}

			return result;
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {value.Value}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation.ToString() ?? "<EMPTY EXPECTATION>";
}
