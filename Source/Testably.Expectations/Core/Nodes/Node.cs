using System;

namespace Testably.Expectations.Core.Nodes;

internal abstract class Node
{
	public static Node None { get; } = new NoneNode();

	public abstract ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value);

	/// <inheritdoc />
	public override string ToString()
		=> "NONE";

	private sealed class NoneNode : Node
	{
		/// <inheritdoc />
		public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
			where TValue : default
			=> throw new InvalidOperationException(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?");
	}
}
