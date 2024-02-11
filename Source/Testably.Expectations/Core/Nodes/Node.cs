using System;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	public static Node None { get; } = new NoneNode();

	public abstract ExpectationResult ApplyTo<TExpectation>(TExpectation actual);

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}
}
