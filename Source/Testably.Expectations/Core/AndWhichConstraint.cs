using System;

namespace Testably.Expectations.Core;

public class AndWhichConstraint<TStart, TCurrent> : AndConstraint<TStart, TCurrent>,
	IShould<TStart, TCurrent>
{
	internal AndWhichConstraint(IConstraintBuilder constraintBuilder) : base(constraintBuilder)
	{
	}

	#region IShould<TStart,TCurrent> Members

	public ShouldBe Be => throw new NotImplementedException();

	public ShouldContain Contain => throw new NotImplementedException();

	public ShouldEnd End => throw new NotImplementedException();

	public ShouldHave Have => throw new NotImplementedException();

	public ShouldStart Start => throw new NotImplementedException();

	public ShouldThrow Throw => throw new NotImplementedException();

	#endregion
}
