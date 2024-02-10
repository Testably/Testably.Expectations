namespace Testably.Expectations.Core.ExpectationBuilders;

internal interface IExpectationBuilderCombination : IExpectationBuilder
{
	IExpectationBuilder Left { get; }

	IExpectationBuilderStart ReplaceRight(IExpectationBuilderStart right);
}
