namespace Testably.Expectations.Core.Nodes;

internal class NotNode : Node
{
	public Node Inner { get; set; }

	public NotNode(Node inner)
	{
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult result = Inner.ApplyTo(actual);
		return result.Invert(e => $"not {e.ExpectationText}",
			v => v == null ? "it did" : $"found {v}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"NOT {Inner}";
}
