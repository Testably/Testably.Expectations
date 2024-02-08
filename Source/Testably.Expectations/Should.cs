using Testably.Expectations.Core;
using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations;

public static class Should
{
	public static ShouldBe Be => new(new SimpleConstraintBuilder());
	public static ShouldContain Contain => new(new SimpleConstraintBuilder());
	public static ShouldEnd End => new(new SimpleConstraintBuilder());
	public static ShouldHave Have => new(new SimpleConstraintBuilder());
	public static ShouldStart Start => new(new SimpleConstraintBuilder());
	public static ShouldThrow Throw => new(new SimpleConstraintBuilder());
}
