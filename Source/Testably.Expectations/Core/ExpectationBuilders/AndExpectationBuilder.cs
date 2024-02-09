using System.Diagnostics;

namespace Testably.Expectations.Core.ExpectationBuilders;

[StackTraceHidden]
internal class AndExpectationBuilder : IExpectationBuilderCombination, IExpectationBuilderStart
{
	public IExpectationBuilder Left { get; }
	private readonly IExpectationBuilderStart _right = new SimpleExpectationBuilder();

	internal AndExpectationBuilder(IExpectationBuilder left)
	{
		Left = left;
	}

	#region IExpectationBuilder Members

	/// <inheritdoc cref="IExpectationBuilderStart.Add(IExpectation)" />
	public IExpectationBuilderStart Add(IExpectation expectation)
	{
		_right.Add(expectation);
		return this;
	}

	/// <inheritdoc cref="IExpectationBuilder.ApplyTo{TExpectation}(TExpectation)" />
	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = Left.ApplyTo(actual);
		ExpectationResult rightResult = _right.ApplyTo(actual);

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return new ExpectationResult.Failure(
				$"{leftFailure.ExpectationText} and {rightFailure.ExpectationText}",
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		if (leftResult is ExpectationResult.Success)
		{
			return rightResult;
		}
		return leftResult;
	}

	#endregion
}
