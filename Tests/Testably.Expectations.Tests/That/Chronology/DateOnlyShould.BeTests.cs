#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class DateOnlyShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			DateOnly subject = CurrentTime();
			DateOnly expected = LaterTime();

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
			DateOnly subject = CurrentTime();
			DateOnly expected = subject;

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
			DateOnly subject = CurrentTime();
			DateOnly unexpected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			DateOnly subject = CurrentTime();
			DateOnly unexpected = subject;

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
#endif
