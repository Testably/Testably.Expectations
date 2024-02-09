using Testably.Expectations.Core;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations;

public static class Should
{
	public static ShouldBe Be => new(new SimpleExpectationBuilder());
	public static ShouldEnd End => new(new SimpleExpectationBuilder());
	public static ShouldStart Start => new(new SimpleExpectationBuilder());
	public static ShouldThrow Throw => new(new SimpleExpectationBuilder());
}
