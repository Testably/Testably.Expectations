using System;
using Testably.Expectations.Core.Internal;
using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class Expectation<TExpectation> : Expectation<TExpectation, TExpectation>
{
	internal Expectation(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class Expectation<TExpectation, TProperty>
{
	private readonly IConstraintBuilder _constraintBuilder;

	internal Expectation(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = constraintBuilder;
	}

	public IShould<TExpectation, TProperty> And()
		=> new AndShould<TExpectation, TProperty>(_constraintBuilder);

	public IShould<TExpectation, TProperty> Or()
		=> new OrShould<TExpectation, TProperty>(_constraintBuilder);

	internal ExpectationResult ApplyTo(TExpectation actual)
		=> _constraintBuilder.ApplyTo(actual);
}

public class Expectation
{
	private readonly IConstraintBuilder _constraintBuilder;

	internal Expectation(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = constraintBuilder;
	}

	public IShould And() => throw new NotImplementedException();

	internal ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
		=> _constraintBuilder.ApplyTo(actual);
}
