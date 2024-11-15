using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Internal.Tests.TestHelpers;

internal class MyConstraint(bool isSuccess = true, string name = "", string failReason = "")
	: IValueConstraint<int>
{
	#region IValueConstraint<int> Members

	/// <inheritdoc />
	public ConstraintResult IsMetBy(int actual)
	{
		if (isSuccess)
		{
			return new ConstraintResult.Success(ToString());
		}

		return new ConstraintResult.Failure(ToString(), failReason);
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> name;
}
