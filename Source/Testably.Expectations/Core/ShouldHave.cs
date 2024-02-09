using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldHave : ShouldVerb
{
	internal ShouldHave(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder) { }
}
