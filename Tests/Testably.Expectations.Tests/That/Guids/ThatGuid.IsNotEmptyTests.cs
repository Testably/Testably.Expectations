namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatGuid
{
	public sealed class IsNotEmptyTests
	{
		[Fact]
		public async Task WhenSubjectIsEmpty_ShouldFail()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not empty,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNotEmpty()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNotEmpty_ShouldSucceed()
		{
			Guid subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
