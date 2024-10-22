namespace Testably.Expectations.Tests.That.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsNotNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNotNull_ShouldSucceed()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not null,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotNull()
				                  """);
		}
	}
}
