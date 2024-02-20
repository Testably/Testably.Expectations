using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Nodes;

internal class AsyncCastNode<T1, T2> : ManipulationNode
{
	public IAsyncExpectation<T1, T2> Expectation { get; }
	public override Node Inner { get; set; }

	public AsyncCastNode(IAsyncExpectation<T1, T2> expectation, Node inner)
	{
		Expectation = expectation;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		throw new InvalidOperationException(
			$"The expectation '{Expectation}' can only be used asynchronously.");
	}

	/// <inheritdoc />
	public override async Task<ExpectationResult> IsMetByAsync<TExpectation>(TExpectation actual)
	{
		if (Expectation is IAsyncExpectation<TExpectation> typedExpectation)
		{
			ExpectationResult result = await typedExpectation.IsMetByAsync(actual);
			if (Inner != None && result is ExpectationResult.Success<T2> success)
			{
				return await Inner.IsMetByAsync(success.Value);
			}

			return result;
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {actual}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation.ToString() ?? "<EMPTY EXPECTATION>";
}
