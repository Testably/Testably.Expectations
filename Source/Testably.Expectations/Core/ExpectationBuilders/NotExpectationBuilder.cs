using System.Diagnostics;

namespace Testably.Expectations.Core.ExpectationBuilders;

[StackTraceHidden]
internal class NotExpectationBuilder : IExpectationBuilderStart
{
	private readonly IExpectationBuilderStart _expectationBuilder;

	public NotExpectationBuilder(IExpectationBuilderStart expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	#region IExpectationBuilderStart Members

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult result = _expectationBuilder.ApplyTo(actual);
		return result.Invert(e => $"not {e.ExpectationText}", "it did");
	}

	/// <inheritdoc />
	public IExpectationBuilderStart Add(IExpectation expectation)
	{
		_expectationBuilder.Add(expectation);
		return this;
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"NOT {_expectationBuilder}";
}
