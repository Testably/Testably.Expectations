namespace Testably.Expectations.Tests;

public class ExpectTests
{
	public class ThatAnyTests
	{
		[Fact]
		public async Task ShouldEvaluateAndDisplayAllExpectations()
		{
			bool subjectA = false;
			bool subjectB = false;

			async Task Act()
				=> await ThatAny(
					That(subjectA).Should().BeTrue(),
					That(subjectB).Should().BeTrue());

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected any of the following to succeed:
				              [01] Expected subjectA to be True
				              [02] Expected subjectB to be True
				             but
				              [01] found False
				              [02] found False
				             """);
		}

		[Theory]
		[InlineData(true, true)]
		[InlineData(true, false)]
		[InlineData(false, true)]
		public async Task WhenAnyConditionIsMet_ShouldSucceed(bool subjectA, bool subjectB)
		{
			async Task Act()
				=> await ThatAny(
					That(subjectA).Should().BeTrue(),
					That(subjectB).Should().BeTrue());

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNoExpectationWasProvided_ShouldThrowArgumentException()
		{
			async Task Act()
				=> await ThatAny();

			await That(Act).Should().Throw<ArgumentException>()
				.WithParamName("expectations").And
				.WithMessage("You must provide at least one expectation*").AsWildcard();
		}
	}

	public class ThatAllTests
	{
		[Theory]
		[InlineData(true, false)]
		[InlineData(false, true)]
		public async Task ShouldEvaluateAndDisplayAllExpectations(bool subjectA, bool subjectB)
		{
			async Task Act()
				=> await ThatAll(
					That(subjectA).Should().BeTrue(),
					That(subjectB).Should().BeTrue());

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected all of the following to succeed:
				               [01] Expected subjectA to be True
				               [02] Expected subjectB to be True
				              but
				               [{(subjectB ? "01" : "02")}] found False
				              """);
		}

		[Fact]
		public async Task WhenAllConditionIsMet_ShouldSucceed()
		{
			bool subjectA = true;
			bool subjectB = true;

			async Task Act()
				=> await ThatAll(
					That(subjectA).Should().BeTrue(),
					That(subjectB).Should().BeTrue());

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenBothConditionsAreNotMet_ShouldFail()
		{
			bool subjectA = false;
			bool subjectB = false;

			async Task Act()
				=> await ThatAll(
					That(subjectA).Should().BeTrue(),
					That(subjectB).Should().BeTrue());

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected all of the following to succeed:
				              [01] Expected subjectA to be True
				              [02] Expected subjectB to be True
				             but
				              [01] found False
				              [02] found False
				             """);
		}

		[Fact]
		public async Task WhenNoExpectationWasProvided_ShouldThrowArgumentException()
		{
			async Task Act()
				=> await ThatAll();

			await That(Act).Should().Throw<ArgumentException>()
				.WithParamName("expectations").And
				.WithMessage("You must provide at least one expectation*").AsWildcard();
		}
	}
}
