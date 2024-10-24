namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBoolShould
{
	public sealed class BeNullTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be <null>,
				                  but found False
				                  at Expect.That(subject).Should().BeNull()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be <null>,
				                  but found True
				                  at Expect.That(subject).Should().BeNull()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
