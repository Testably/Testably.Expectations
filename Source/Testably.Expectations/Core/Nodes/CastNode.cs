using System;

namespace Testably.Expectations.Core.Nodes;

internal class CastNode<T1, T2> : Node
{
	public IExpectation<T1, T2>? Expectation { get; }
	public Node Inner { get; set; }

	public CastNode(IExpectation<T1, T2> expectation, Node inner)
	{
		Expectation = expectation;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		if (Expectation is IExpectation<TExpectation> typedExpectation)
		{
			ExpectationResult result = typedExpectation.IsMetBy(actual);
			if (Inner != None && result is ExpectationResult.Success<T2> success)
			{
				return Inner.ApplyTo(success.Value);
			}

			return result;
		}

		if (Expectation is null)
		{
			throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {actual}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation?.ToString() ?? "<EMPTY EXPECTATION>";
}
