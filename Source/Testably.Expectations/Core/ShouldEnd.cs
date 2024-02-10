using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to end…
/// </summary>
public class ShouldEnd : ShouldVerb
{
	internal ShouldEnd(IExpectationBuilderStart expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
