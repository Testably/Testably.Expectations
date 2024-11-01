namespace Testably.Expectations.Tests.ThatTests.Guids;

public sealed partial class GuidShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenExpectedIsNull_ShouldFail()
		{
			Guid subject = FixedGuid();
			Guid? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be <null>,
				              but found {subject}
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			Guid subject = FixedGuid();
			Guid expected = OtherGuid();

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

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			Guid subject = FixedGuid();
			Guid expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			Guid subject = FixedGuid();
			Guid unexpected = OtherGuid();

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			Guid subject = FixedGuid();
			Guid unexpected = subject;

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
		public async Task WhenUnexpectedIsNull_ShouldSucceed()
		{
			Guid subject = FixedGuid();
			Guid? unexpected = null;

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().NotThrow();
		}
	}
}
