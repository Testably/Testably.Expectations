using System.Diagnostics;

namespace Testably.Expectations.Core.ExpectationBuilders;

[StackTraceHidden]
internal class OrExpectationBuilder : IExpectationBuilderCombination, IExpectationBuilderStart
{
	private IExpectationBuilderStart _right = new SimpleExpectationBuilder();

	internal OrExpectationBuilder(IExpectationBuilder left)
	{
		Left = left;
	}

	#region IExpectationBuilderCombination Members

	public IExpectationBuilder Left { get; }

	/// <inheritdoc />
	public IExpectationBuilderStart ReplaceRight(IExpectationBuilderStart right)
	{
		_right = right;
		return this;
	}

	/// <inheritdoc cref="IExpectationBuilder.ApplyTo{TExpectation}(TExpectation)" />
	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = Left.ApplyTo(actual);
		ExpectationResult rightResult = _right.ApplyTo(actual);

		var combinedExpectation = $"{leftResult.ExpectationText} or {rightResult.ExpectationText}";

		if (leftResult is ExpectationResult.Failure leftFailure &&
		    rightResult is ExpectationResult.Failure rightFailure)
		{
			return new ExpectationResult.Failure(
				combinedExpectation,
				$"{leftFailure.ResultText} and {rightFailure.ResultText}");
		}

		return new ExpectationResult.Success(combinedExpectation);
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
