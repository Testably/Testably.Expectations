namespace Testably.Expectations.Core.Nodes;

internal class NotNode : ManipulationNode
{
	private readonly string _textSeparator;
	public override Node Inner { get; set; }

	public NotNode(Node inner, string textSeparator = "not ")
	{
		_textSeparator = textSeparator;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		ExpectationResult result = Inner.IsMetBy(value);
		return result.Invert(e => $"{_textSeparator}{e.ExpectationText}",
			v => v == null ? "it did" : $"found {v}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"NOT {Inner}";
}
