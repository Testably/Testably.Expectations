namespace Testably.Expectations.Core;

public interface IShould
{
	public ShouldBe Be { get; }
	public ShouldEnd End { get; }
	public ShouldStart Start { get; }
	public ShouldThrow Throw { get; }
}

public interface IShould<TStart, TCurrent> : IShould
{
}
