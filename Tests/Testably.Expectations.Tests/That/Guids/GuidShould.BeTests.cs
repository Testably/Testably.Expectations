namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class GuidShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			Guid subject = FixedGuid();
			Guid expected = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
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
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
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
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			Guid subject = FixedGuid();
			Guid unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   not be {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().NotBe(unexpected)
				                   """);
		}
	}
}
