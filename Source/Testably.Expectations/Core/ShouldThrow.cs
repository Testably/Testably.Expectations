using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldThrow : ShouldVerb
{
	internal ShouldThrow(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder) { }
}
