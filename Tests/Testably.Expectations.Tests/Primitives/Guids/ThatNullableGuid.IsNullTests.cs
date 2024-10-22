namespace Testably.Expectations.Tests.Primitives.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsNullTests
	{
		[Fact]
		public async Task WhenSubjectIsNotNull_ShouldFail()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is null,
				                   but found {subject}
				                   at Expect.That(subject).IsNull()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
