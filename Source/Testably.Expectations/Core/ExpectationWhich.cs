using System;
using System.Linq.Expressions;
using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ExpectationWhich<TStart, TCurrent> : Expectation<TStart, TCurrent>,
	IShould<TStart, TCurrent>
{
	private readonly IConstraintBuilder _constraintBuilder;

	internal ExpectationWhich(IConstraintBuilder constraintBuilder) : base(constraintBuilder)
	{
		_constraintBuilder = constraintBuilder;
	}

	public Expectation<TStart, TCurrent> Which<TProperty>(
		Expression<Func<TCurrent, TProperty>> propertySelector,
		Expectation<TProperty> constraint)
		=> new(new WhichConstraintBuilder<TCurrent, TProperty>(_constraintBuilder, propertySelector, constraint));

	#region IShould<TStart,TCurrent> Members

	public ShouldBe Be => new(_constraintBuilder);

	public ShouldContain Contain => new(_constraintBuilder);

	public ShouldEnd End => new(_constraintBuilder);

	public ShouldHave Have => new(_constraintBuilder);

	public ShouldStart Start => new(_constraintBuilder);

	public ShouldThrow Throw => new(_constraintBuilder);

	#endregion
}
