using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldStart : ShouldVerb
{
	internal ShouldStart(IExpectationBuilderStart expectationBuilder)
		: base(expectationBuilder) { }
}
