using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldBe : ShouldVerb
{
	internal ShouldBe(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder) { }
}
