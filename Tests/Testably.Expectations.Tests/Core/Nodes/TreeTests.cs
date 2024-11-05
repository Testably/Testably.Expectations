using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Results;

namespace Testably.Expectations.Tests.Core.Nodes;

public class TreeTests
{
	[Fact]
	public async Task AddCastConstraintWithoutCombination_ShouldThrowInvalidOperationException()
	{
		IThat<bool> that = That(true).Should();
		that.ExpectationBuilder.AddConstraint(new DummyConstraint());

		await That(() => that.ExpectationBuilder.AddConstraint(new DummyCastConstraint()))
			.Should().Throw<InvalidOperationException>()
			.WithMessage(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
	}

	[Fact]
	public async Task AddConstraintTwice_ShouldThrowInvalidOperationException()
	{
		IThat<bool> that = That(true).Should();
		that.ExpectationBuilder.AddConstraint(new DummyConstraint());

		await That(() => that.ExpectationBuilder.AddConstraint(new DummyConstraint()))
			.Should().Throw<InvalidOperationException>()
			.WithMessage(
				"You have to specify how to combine the expectations! Use `And()` or `Or()` in between adding expectations.");
	}

	[Fact]
	public async Task CallAndTwice_ShouldThrowInvalidOperationException()
	{
		AndOrResult<bool, IThat<bool>> result = That(true).Should().BeTrue();
		_ = result.And;

		await That(() => result.And)
			.Should().Throw<InvalidOperationException>()
			.WithMessage(
				"You have to specify expectations between combinations! Add expectations between `And()` or `Or()`.");
	}

	private class DummyCastConstraint : ICastConstraint<bool, bool>
	{
		#region ICastConstraint<bool,bool> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(bool actual)
			=> new ConstraintResult.Success("");

		#endregion
	}

	private class DummyConstraint : IValueConstraint<bool>
	{
		#region IValueConstraint<bool> Members

		/// <inheritdoc />
		public ConstraintResult IsMetBy(bool actual)
			=> new ConstraintResult.Success("");

		#endregion
	}
}
