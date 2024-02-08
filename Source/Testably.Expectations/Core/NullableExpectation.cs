using System;
using Testably.Expectations.Core.Internal;
using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class NullableExpectation<TExpectation> : NullableExpectation<TExpectation, TExpectation>
{
	internal NullableExpectation(IConstraintBuilder constraintBuilder) : base(constraintBuilder)
	{
	}
}

public class NullableExpectation<TExpectation, TCurrent>
{
	private readonly IConstraintBuilder _constraintBuilder;

	internal NullableExpectation(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = constraintBuilder;
	}

	public IShould<TExpectation, TCurrent> And() => throw new NotImplementedException();

	internal ExpectationResult ApplyTo(TExpectation actual)
		=> _constraintBuilder.ApplyTo(actual);
}

public class NullableExpectation
{
	private readonly IConstraintBuilder _constraintBuilder;

	internal NullableExpectation(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = constraintBuilder;
	}

	public IShould And() => throw new NotImplementedException();

	internal ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
		=> _constraintBuilder.ApplyTo(actual);
}
