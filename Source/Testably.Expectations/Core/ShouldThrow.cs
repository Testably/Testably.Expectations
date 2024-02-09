using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class ShouldThrow : ShouldVerb
{
	internal ShouldThrow(IExpectationBuilderStart expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
