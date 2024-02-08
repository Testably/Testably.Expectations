using Testably.Expectations.Core;

namespace Testably.Expectations;

public static class Should
{
	public static ShouldBe Be => new(new WithoutConstraints());
	public static ShouldContain Contain => new(new WithoutConstraints());
	public static ShouldEnd End => new(new WithoutConstraints());
	public static ShouldHave Have => new(new WithoutConstraints());
	public static ShouldStart Start => new(new WithoutConstraints());
	public static ShouldThrow Throw => new(new WithoutConstraints());
}
