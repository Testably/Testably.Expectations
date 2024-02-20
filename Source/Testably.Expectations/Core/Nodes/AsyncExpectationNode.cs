using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Nodes;

internal class AsyncExpectationNode : Node
{
	public IAsyncExpectation Expectation { get; }

	public AsyncExpectationNode(IAsyncExpectation expectation)
	{
		Expectation = expectation;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		throw new InvalidOperationException(
			$"The expectation '{Expectation}' can only be used asynchronously.");
	}

	/// <inheritdoc />
	public override Task<ExpectationResult> IsMetByAsync<TExpectation>(TExpectation actual)
	{
		if (Expectation is IAsyncExpectation<TExpectation> typedExpectation)
		{
			return typedExpectation.IsMetByAsync(actual);
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {actual}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> Expectation.ToString() ?? "<EMPTY EXPECTATION>";
}
