namespace Testably.Expectations.Tests.ThatTests.Booleans;

public sealed partial class BoolShould
{
	public sealed class BeTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsDifferent_ShouldFail(bool subject)
		{
			bool expected = !subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected},
				              but found {subject}.
				              """);
		}

		[Theory]
		[InlineAutoData(true)]
		[InlineAutoData(false)]
		public async Task WhenSubjectIsDifferent_ShouldFailWithDescriptiveMessage(
			bool subject, string reason)
		{
			bool expected = !subject;

			async Task Act()
				=> await That(subject).Should().Be(expected).Because(reason);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be {expected}, because {reason},
				              but found {subject}.
				              """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(bool subject)
		{
			bool expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(bool subject)
		{
			bool unexpected = !subject;

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsTheSame_ShouldFail(bool subject)
		{
			bool unexpected = subject;

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be {unexpected},
				              but found {subject}.
				              """);
		}

		[Theory]
		[InlineAutoData(true)]
		[InlineAutoData(false)]
		public async Task WhenSubjectIsTheSame_ShouldFailWithDescriptiveMessage(
			bool subject, string reason)
		{
			bool unexpected = subject;

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected).Because(reason);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be {unexpected}, because {reason},
				              but found {subject}.
				              """);
		}
	}
}
