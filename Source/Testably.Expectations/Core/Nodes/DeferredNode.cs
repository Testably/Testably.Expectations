using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Nodes;

internal class DeferredNode<TProperty, TThatProperty> : Node
where TThatProperty : That<TProperty>
{
	private readonly Action<TThatProperty> _expectation;
	private readonly Func<IExpectationBuilder, TThatProperty> _thatPropertyFactory;

	public DeferredNode(Action<TThatProperty> expectation,
	Func<IExpectationBuilder, TThatProperty> thatPropertyFactory)
	{
		_expectation = expectation;
		_thatPropertyFactory = thatPropertyFactory;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		SourceValue<TValue> value,
		IEvaluationContext context)
		where TValue : default
	{
		if (value is not SourceValue<TProperty> matchingActualValue)
		{
			throw new InvalidOperationException(
				$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TProperty).Name},{Environment.NewLine}but found {value.Value?.GetType().Name}");
		}

		ExpectationBuilder<TProperty?> expectationBuilder = new(matchingActualValue.Value, "");
		_expectation.Invoke(_thatPropertyFactory(expectationBuilder));
		return await expectationBuilder.IsMet();
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"Deferred node of {typeof(TProperty).Name}";
}
