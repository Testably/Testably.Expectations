namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNotNull_ShouldFail()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is null,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNull()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
