using System;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

public class NullableExpectation<TExpectation> : NullableExpectation<TExpectation, TExpectation>
{
	internal NullableExpectation(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
	{
	}
}

public class NullableExpectation<TExpectation, TCurrent>
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal NullableExpectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public IShould<TExpectation, TCurrent> And() => throw new NotImplementedException();

	internal ExpectationResult ApplyTo(TExpectation actual)
		=> _expectationBuilder.ApplyTo(actual);
}

public class NullableExpectation
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal NullableExpectation(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public IShould And() => throw new NotImplementedException();

	internal ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
		=> _expectationBuilder.ApplyTo(actual);
}
