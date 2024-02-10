using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to throw…
/// </summary>
public class ShouldThrow : ShouldVerb
{
	internal ShouldThrow(IExpectationBuilderStart expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
