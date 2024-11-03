using System;
using System.Threading;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core.Nodes;

internal class DeferredNode<TTarget> : Node
{
	private readonly Action<ExpectationBuilder> _expectation;

	public DeferredNode(Action<ExpectationBuilder> expectation)
	{
		_expectation = expectation;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context,
		CancellationToken cancellationToken)
		where TValue : default
	{
		if (value is not TTarget matchingActualValue)
		{
			throw new InvalidOperationException(
				$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TTarget).Name},{Environment.NewLine}but found {value?.GetType().Name}");
		}

		ExpectationBuilder<TTarget?> expectationBuilder =
			new(new ValueSource<TTarget?>(matchingActualValue), "");
		_expectation.Invoke(expectationBuilder);
		return await expectationBuilder.IsMet();
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"Deferred node of {typeof(TTarget).Name}";
}
