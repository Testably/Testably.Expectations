namespace Testably.Expectations.Tests.Primitives.Guids;

public sealed partial class ThatNullableGuid
{
	public sealed class IsNotEmptyTests
	{
		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			Guid? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNotEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not empty,
				                  but found <null>
				                  at Expect.That(subject).IsNotEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenValueIsEmpty_ShouldFail()
		{
			Guid subject = Guid.Empty;

			async Task Act()
				=> await Expect.That(subject).IsNotEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not empty,
				                   but found {subject}
				                   at Expect.That(subject).IsNotEmpty()
				                   """);
		}

		[Fact]
		public async Task WhenValueIsNotEmpty_ShouldSucceed()
		{
			Guid? subject = OtherGuid();

			async Task Act()
				=> await Expect.That(subject).IsNotEmpty();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
