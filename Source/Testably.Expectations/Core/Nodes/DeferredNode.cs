using System;

namespace Testably.Expectations.Core.Nodes;

internal class DeferredNode<TProperty> : Node
{
	private readonly Action<That<TProperty>> _expectation;

	public DeferredNode(Action<That<TProperty>> expectation)
	{
		_expectation = expectation;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		if (value is not SourceValue<TProperty> matchingActualValue)
		{
			throw new InvalidOperationException(
				$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TProperty).Name},{Environment.NewLine}but found {value.Value?.GetType().Name}");
		}

		var expectationBuilder = new ExpectationBuilder<TProperty?>(matchingActualValue.Value, "");
		_expectation.Invoke(new That<TProperty>(expectationBuilder));
		return expectationBuilder.IsMet().Result;
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"Deferred node of {typeof(TProperty).Name}";
}
