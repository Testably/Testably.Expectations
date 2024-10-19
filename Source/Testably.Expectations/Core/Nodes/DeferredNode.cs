﻿using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Nodes;

internal class DeferredNode<TProperty> : Node
{
	private readonly Action<That<TProperty>> _expectation;

	public DeferredNode(Action<That<TProperty>> expectation)
	{
		_expectation = expectation;
	}

	/// <inheritdoc />
	public override async Task<ExpectationResult> IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		if (value is not SourceValue<TProperty> matchingActualValue)
		{
			throw new InvalidOperationException(
				$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TProperty).Name},{Environment.NewLine}but found {value.Value?.GetType().Name}");
		}

		var expectationBuilder = new ExpectationBuilder<TProperty?>(matchingActualValue.Value, "");
		_expectation.Invoke(new That<TProperty>(expectationBuilder));
		return await expectationBuilder.IsMet();
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"Deferred node of {typeof(TProperty).Name}";
}
