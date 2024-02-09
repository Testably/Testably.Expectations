using System;

namespace Testably.Expectations.Core.ExpectationBuilders;

internal class SimpleExpectationBuilder : IExpectationBuilder
{
	private IExpectation? _expectation;

	#region IExpectationBuilder Members

	/// <inheritdoc />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		if (_expectation != null)
		{
			throw new InvalidOperationException(
				$"Cannot add multiple expectations to a {nameof(SimpleExpectationBuilder)}");
		}
		_expectation = expectation;
		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		if (_expectation is IExpectation<TExpectation> typedExpectation)
		{
			return typedExpectation.IsMetBy(actual);
		}

		return new ExpectationResult.Success();
	}

	#endregion

	public override string ToString()
		=> _expectation?.ToString() ?? "no expectation yet";
}
