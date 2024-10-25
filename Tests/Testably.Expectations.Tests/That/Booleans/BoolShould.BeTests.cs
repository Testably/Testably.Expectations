namespace Testably.Expectations.Tests.That.Booleans;

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
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(bool subject)
		{
			bool expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
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
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsTheSame_ShouldFail(bool subject)
		{
			bool unexpected = subject;

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
