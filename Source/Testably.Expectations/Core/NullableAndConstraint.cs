using System;

namespace Testably.Expectations.Core;

public class NullableAndConstraint<TExpectation> : NullableAndConstraint<TExpectation, TExpectation>
{
	internal NullableAndConstraint(IConstraintBuilder constraintBuilder) : base(constraintBuilder)
	{
	}
}

public class NullableAndConstraint<TExpectation, TCurrent>
{
	private readonly IConstraintBuilder _iConstraintBuilder;

	internal NullableAndConstraint(IConstraintBuilder constraintBuilder)
	{
		_iConstraintBuilder = constraintBuilder;
	}

	public IShould<TExpectation, TCurrent> And() => throw new NotImplementedException();

	internal ExpectationResult<TExpectation> ApplyTo(TExpectation actual)
		=> _iConstraintBuilder.ApplyTo(actual);
}

public class NullableAndConstraint
{
	private readonly IConstraintBuilder _iConstraintBuilder;

	internal NullableAndConstraint(IConstraintBuilder constraintBuilder)
	{
		_iConstraintBuilder = constraintBuilder;
	}

	public IShould And() => throw new NotImplementedException();

	internal ExpectationResult<TExpectation> ApplyTo<TExpectation>(TExpectation actual)
		=> _iConstraintBuilder.ApplyTo(actual);
}
