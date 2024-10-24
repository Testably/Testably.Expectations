namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBoolShould
{
	public sealed class BeTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().BeTrue();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be True,
				                  but found False
				                  at Expect.That(subject).Should().BeTrue()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeTrue();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be True,
				                  but found <null>
				                  at Expect.That(subject).Should().BeTrue()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().BeTrue();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
