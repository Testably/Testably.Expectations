using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to start…
/// </summary>
public class ShouldStart : ShouldVerb
{
	internal ShouldStart(IExpectationBuilderStart expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
