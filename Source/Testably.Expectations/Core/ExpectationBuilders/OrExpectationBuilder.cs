using System.Diagnostics;

namespace Testably.Expectations.Core.ExpectationBuilders;

[StackTraceHidden]
internal class OrExpectationBuilder : IExpectationBuilderCombination, IExpectationBuilderStart
{
	private readonly IExpectationBuilderStart _right = new SimpleExpectationBuilder();

	internal OrExpectationBuilder(IExpectationBuilder left)
	{
		Left = left;
	}

	#region IExpectationBuilderCombination Members

	public IExpectationBuilder Left { get; }

	/// <inheritdoc cref="IExpectationBuilder.ApplyTo{TExpectation}(TExpectation)" />
	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = Left.ApplyTo(actual);
		ExpectationResult rightResult = _right.ApplyTo(actual);

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return new ExpectationResult.Failure(
				$"{leftFailure.ExpectationText} or {rightFailure.ExpectationText}",
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		return new ExpectationResult.Success();
	}

	#endregion

	#region IExpectationBuilderStart Members

	/// <inheritdoc cref="IExpectationBuilderStart.Add(IExpectation)" />
	public IExpectationBuilderStart Add(IExpectation expectation)
	{
		_right.Add(expectation);
		return this;
	}

	#endregion
}
