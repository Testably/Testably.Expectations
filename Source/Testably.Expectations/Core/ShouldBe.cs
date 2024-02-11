namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to be…
/// </summary>
public class ShouldBe : ShouldVerb
{
	internal ShouldBe(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
