namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatGuid
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			Guid subject = FixedGuid();
			Guid unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			Guid subject = FixedGuid();
			Guid unexpected = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
