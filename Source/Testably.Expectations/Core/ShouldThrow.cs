namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to throw…
/// </summary>
public class ShouldThrow : ShouldVerb
{
	internal ShouldThrow(IExpectationBuilder expectationBuilder)
		: base(expectationBuilder)
	{
	}
}
