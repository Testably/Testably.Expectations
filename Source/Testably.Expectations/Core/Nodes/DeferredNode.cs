using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Nodes;

//TODO VAB: Remove
internal class LegacyDeferredNode<TProperty, TThatProperty> : Node
where TThatProperty : IThat<TProperty>
{
	private readonly Action<TThatProperty> _expectation;
	private readonly Func<ExpectationBuilder, TThatProperty> _thatPropertyFactory;

	public LegacyDeferredNode(Action<TThatProperty> expectation,
	Func<ExpectationBuilder, TThatProperty> thatPropertyFactory)
	{
		_expectation = expectation;
		_thatPropertyFactory = thatPropertyFactory;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context)
		where TValue : default
	{
		if (value is not SourceValue<TProperty> matchingActualValue)
		{
			throw new InvalidOperationException(
				$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TProperty).Name},{Environment.NewLine}but found {value?.GetType().Name}");
		}

		ExpectationBuilder<TProperty?> expectationBuilder = new(matchingActualValue.Value, "");
		_expectation.Invoke(_thatPropertyFactory(expectationBuilder));
		return await expectationBuilder.IsMet();
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"Deferred node of {typeof(TProperty).Name}";
}


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
		IEvaluationContext context)
		where TValue : default
	{
		if (value is not TTarget matchingActualValue)
		{
			throw new InvalidOperationException(
				$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TTarget).Name},{Environment.NewLine}but found {value?.GetType().Name}");
		}

		ExpectationBuilder<TTarget?> expectationBuilder2 = new(matchingActualValue, "");
		_expectation.Invoke(expectationBuilder2);
		return await expectationBuilder2.IsMet();
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"Deferred node of {typeof(TTarget).Name}";
}
