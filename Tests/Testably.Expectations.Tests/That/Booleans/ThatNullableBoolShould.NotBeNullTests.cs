namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBoolShould
{
	public sealed class NotBeNullTests
	{
		[Fact]
		public async Task WhenFalse_ShouldSucceed()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be <null>,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeNull()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
