using System;

namespace Testably.Expectations.Core;

public class AndConstraint<TExpectation> : AndConstraint<TExpectation, TExpectation>
{
	internal AndConstraint(IConstraintBuilder constraintBuilder) : base(constraintBuilder) { }
}

public class AndConstraint<TExpectation, TProperty>
{
	private readonly IConstraintBuilder _iConstraintBuilder;

	internal AndConstraint(IConstraintBuilder constraintBuilder)
	{
		_iConstraintBuilder = constraintBuilder;
	}

	public IShould<TExpectation, TProperty> And()
		=> new AndShould<TExpectation, TProperty>(_iConstraintBuilder);

	public IShould<TExpectation, TProperty> Or()
		=> new OrShould<TExpectation, TProperty>(_iConstraintBuilder);

	internal ExpectationResult<TExpectation> ApplyTo(TExpectation actual)
		=> _iConstraintBuilder.ApplyTo(actual);
}

public class AndConstraint
{
	private readonly IConstraintBuilder _iConstraintBuilder;

	internal AndConstraint(IConstraintBuilder constraintBuilder)
	{
		_iConstraintBuilder = constraintBuilder;
	}

	public IShould And() => throw new NotImplementedException();

	internal ExpectationResult<TExpectation> ApplyTo<TExpectation>(TExpectation actual)
		=> _iConstraintBuilder.ApplyTo(actual);
}
