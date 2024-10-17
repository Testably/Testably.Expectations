namespace Testably.Expectations.Core.Nodes;

internal class NotNode : ManipulationNode
{
	public override Node Inner { get; set; }

	public NotNode(Node inner)
	{
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		ExpectationResult result = Inner.IsMetBy(value);
		return result.Invert(e => $"not {e.ExpectationText}",
			v => v == null ? "it did" : $"found {v}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"NOT {Inner}";
}
