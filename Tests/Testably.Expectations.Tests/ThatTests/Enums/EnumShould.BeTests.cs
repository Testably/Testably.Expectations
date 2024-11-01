namespace Testably.Expectations.Tests.ThatTests.Enums;

public sealed partial class EnumShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenExpectedIsNull_ShouldFail()
		{
			MyColors subject = MyColors.Yellow;

			async Task Act()
				=> await That(subject).Should().Be(null);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be <null>,
				              but found {subject}
				              at Expect.That(subject).Should().Be(null)
				              """);
		}

		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		public async Task WhenSubjectIsDifferent_ShouldFail(MyColors subject, MyColors expected)
		{
			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected},
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(MyColors subject)
		{
			MyColors expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(MyColors subject,
			MyColors unexpected)
		{
			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors subject)
		{
			MyColors unexpected = subject;

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be {unexpected},
				              but found {subject}
				              at Expect.That(subject).Should().NotBe(unexpected)
				              """);
		}

		[Fact]
		public async Task WhenUnexpectedIsNull_ShouldFail()
		{
			MyColors subject = MyColors.Yellow;

			async Task Act()
				=> await That(subject).Should().NotBe(null);

			await That(Act).Should().NotThrow();
		}
	}
}
