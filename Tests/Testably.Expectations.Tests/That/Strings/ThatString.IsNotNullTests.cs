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

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldSucceed(string? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldFail()
		{
			string? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not null,
				                  but it was
				                  at Expect.That(subject).Should().IsNotNull()
				                  """);
		}
	}
}
