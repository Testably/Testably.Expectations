namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class EnumShould
{
	public sealed class BeTests
	{
		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		public async Task WhenSubjectIsDifferent_ShouldFail(MyColors subject, MyColors expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
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
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
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
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors subject)
		{
			MyColors unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                    Expected subject to
				                    not be {unexpected},
				                    but found {subject}
				                    at Expect.That(subject).Should().NotBe(unexpected)
				                    """);
		}
	}
}
