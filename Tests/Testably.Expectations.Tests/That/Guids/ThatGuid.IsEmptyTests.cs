namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatGuid
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task WhenSubjectIsEmpty_ShouldSucceed()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotEmpty_ShouldFail()
		{
			Guid subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is empty,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsEmpty()
				                   """);
		}
	}
}
