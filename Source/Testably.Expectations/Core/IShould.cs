namespace Testably.Expectations.Core;

public interface IShould
{
	public ShouldBe Be { get; }
	public ShouldContain Contain { get; }
	public ShouldEnd End { get; }
	public ShouldHave Have { get; }
	public ShouldStart Start { get; }
	public ShouldThrow Throw { get; }
}

public interface IShould<TStart, TCurrent> : IShould
{
}
