using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldBe : ShouldVerb
{
	internal ShouldBe(IExpectationBuilderStart expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
