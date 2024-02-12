namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to contain…
/// </summary>
public class ShouldContain : ShouldVerb
{
	internal ShouldContain(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
