using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldContain : ShouldVerb
{
	internal ShouldContain(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder) { }
}
