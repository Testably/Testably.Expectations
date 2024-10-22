namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public sealed class IsNotNullTests
	{
		[Fact]
		public async Task WhenActualIsEmpty_ShouldSucceed()
		{
			string subject = "";

			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldSucceed(string? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldFail()
		{
			string? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not null,
				                  but it was
				                  at Expect.That(subject).Should().IsNotNull()
				                  """);
		}
	}
}
