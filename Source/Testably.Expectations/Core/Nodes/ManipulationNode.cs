namespace Testably.Expectations.Core.Nodes;

internal abstract class ManipulationNode : Node
{
	public abstract Node Inner { get; set; }
}
