namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class DateTimeShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime();

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
			DateTime subject = CurrentTime();
			DateTime expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                    Expected subject to
				                    be {expected:O} ± 0:03,
				                    but found {subject:O}
				                    at Expect.That(subject).Should().Be(expected).Within(TimeSpan.FromSeconds(3))
				                    """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime unexpected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime unexpected = subject;

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

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                    Expected subject to
				                    not be {expected:O} ± 0:03,
				                    but found {subject:O}
				                    at Expect.That(subject).Should().NotBe(expected).Within(TimeSpan.FromSeconds(3))
				                    """);
		}
	}
}
