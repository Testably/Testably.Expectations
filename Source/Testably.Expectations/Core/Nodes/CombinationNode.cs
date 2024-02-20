namespace Testably.Expectations.Core.Nodes;

public abstract class CombinationNode : Node
{
	public abstract Node Left { get; }
	public abstract Node Right { get; set; }
}
