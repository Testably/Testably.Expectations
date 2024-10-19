namespace Testably.Expectations.Core;

public class That<T>(IExpectationBuilder expectationBuilder)
{
	public IExpectationBuilder ExpectationBuilder { get; } = expectationBuilder;
}
