namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class NullableBoolShould
{
	public sealed class BeTests
	{
		[Theory]
		[InlineData(true, false)]
		[InlineData(true, null)]
		[InlineData(false, true)]
		[InlineData(false, null)]
		[InlineData(null, true)]
		[InlineData(null, false)]
		public async Task WhenSubjectIsDifferent_ShouldFail(bool? subject, bool? expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                   Expected subject to
				                   be {expected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Should().Be(expected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		[InlineData(null)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(bool? subject)
		{
			bool? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Theory]
		[InlineData(true, false)]
		[InlineData(true, null)]
		[InlineData(false, true)]
		[InlineData(false, null)]
		[InlineData(null, true)]
		[InlineData(null, false)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(bool? subject, bool? unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		[InlineData(null)]
		public async Task WhenSubjectIsTheSame_ShouldFail(bool? subject)
		{
			bool? unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().NotBe(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                   Expected subject to
				                   not be {unexpected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Should().NotBe(unexpected)
				                   """);
		}
	}
}
