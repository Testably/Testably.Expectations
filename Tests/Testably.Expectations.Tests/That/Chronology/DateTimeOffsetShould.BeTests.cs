namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class DateTimeOffsetShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset expected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                    Expected subject to
				                    be {expected:O},
				                    but found {subject:O}
				                    at Expect.That(subject).Should().Be(expected)
				                    """);
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset expected = subject;

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
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                    Expected subject to
				                    not be {unexpected:O},
				                    but found {subject:O}
				                    at Expect.That(subject).Should().NotBe(unexpected)
				                    """);
		}
	}
}
