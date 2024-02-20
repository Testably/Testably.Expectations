using System;

namespace Testably.Expectations.Core.Nodes;

public abstract class Node
{
	public static Node None { get; } = new NoneNode();

	public abstract ExpectationResult IsMetBy<TExpectation>(TExpectation actual);

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";
}
