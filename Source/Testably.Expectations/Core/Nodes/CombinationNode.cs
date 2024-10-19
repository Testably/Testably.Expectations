namespace Testably.Expectations.Core.Nodes;

internal abstract class CombinationNode : Node
{
	public abstract Node Left { get; }
	public abstract Node Right { get; set; }
}
