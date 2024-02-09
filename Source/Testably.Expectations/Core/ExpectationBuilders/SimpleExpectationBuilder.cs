using System;
using System.Diagnostics;

namespace Testably.Expectations.Core.ExpectationBuilders;

[StackTraceHidden]
internal class SimpleExpectationBuilder : IExpectationBuilderStart
{
	private IExpectation? _expectation;

	#region IExpectationBuilderStart Members

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		if (_expectation is IExpectation<TExpectation> typedExpectation)
		{
			return typedExpectation.IsMetBy(actual);
		}

		throw new InvalidOperationException(
			$"The expectation does not support {typeof(TExpectation).Name} {actual}");
	}

	/// <inheritdoc />
	public IExpectationBuilderStart Add(IExpectation expectation)
	{
		if (_expectation != null)
		{
			throw new InvalidOperationException(
				$"Cannot add multiple expectations to a {nameof(SimpleExpectationBuilder)}");
		}

		_expectation = expectation;
		return this;
	}

	#endregion
}
