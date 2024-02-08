using System;
using Testably.Expectations.Internal.ConstraintBuilders;

namespace Testably.Expectations.Core;

public class ExpectationWhich<TStart, TCurrent> : Expectation<TStart, TCurrent>,
	IShould<TStart, TCurrent>
{
	internal ExpectationWhich(IConstraintBuilder constraintBuilder) : base(constraintBuilder)
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
