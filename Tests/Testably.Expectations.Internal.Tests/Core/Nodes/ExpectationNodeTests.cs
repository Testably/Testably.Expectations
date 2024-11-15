using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Nodes;

namespace Testably.Expectations.Internal.Tests.Core.Nodes;

public class ExpectationNodeTests
{
	[Theory]
	[AutoData]
	public async Task ToString_WhenNodeHasAConstraint_ShouldReturnConstraintName(
		string constraintName)
	{
		ExpectationNode node = new();
		node.AddConstraint(new MyConstraint(name: constraintName));

		await That(node.ToString()).Should().Be(constraintName);
	}

	[Fact]
	public async Task ToString_WhenNodeIsEmpty_ShouldReturnEmptyInBrackets()
	{
		ExpectationNode node = new();

		await That(node.ToString()).Should().Be("<empty>");
	}

	private class MyConstraint(bool isSuccess = true, string name = "", string failReason = "")
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
}
