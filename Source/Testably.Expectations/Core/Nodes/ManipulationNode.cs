namespace Testably.Expectations.Core.Nodes;

public abstract class ManipulationNode : Node
{
	public abstract Node Inner { get; set; }
}
