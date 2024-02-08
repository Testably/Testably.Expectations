namespace Testably.Expectations.Core;

public abstract class ShouldVerb
{
	private readonly IConstraintBuilder _iConstraintBuilder;

	internal ShouldVerb(IConstraintBuilder constraintBuilder)
	{
		_iConstraintBuilder = constraintBuilder;
	}

	internal AndConstraint<T> WithConstraint<T>(IConstraint<T> constraint)
		=> new(_iConstraintBuilder.Add(constraint));

	internal NullableAndConstraint<T> WithConstraint<T>(INullableConstraint<T> constraint)
		=> new(_iConstraintBuilder.Add(constraint));

	internal AndConstraint WithConstraint(IConstraint constraint)
		=> new(_iConstraintBuilder.Add(constraint));

	internal NullableAndConstraint WithConstraint(INullableConstraint constraint)
		=> new(_iConstraintBuilder.Add(constraint));

	internal AndWhichConstraint<T1, T2> WithConstraintMapping<T1, T2>(
		IConstraint<T1, T2> constraint)
		=> new(_iConstraintBuilder.Add(constraint));
}
