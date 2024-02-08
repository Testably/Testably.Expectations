using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public abstract class ShouldVerb
{
	private readonly IConstraintBuilder _constraintBuilder;

	internal ShouldVerb(IConstraintBuilder constraintBuilder)
	{
		_constraintBuilder = constraintBuilder;
	}

	internal Expectation<T> WithConstraint<T>(IConstraint<T> constraint)
		=> new(_constraintBuilder.Add(constraint));

	internal NullableExpectation<T> WithConstraint<T>(INullableConstraint<T> constraint)
		=> new(_constraintBuilder.Add(constraint));

	internal Expectation WithConstraint(IConstraint constraint)
		=> new(_constraintBuilder.Add(constraint));

	internal NullableExpectation WithConstraint(INullableConstraint constraint)
		=> new(_constraintBuilder.Add(constraint));

	internal ExpectationWhich<T1, T2> WithConstraintMapping<T1, T2>(
		IConstraint<T1, T2> constraint)
		=> new(_constraintBuilder.Add(constraint));
}
