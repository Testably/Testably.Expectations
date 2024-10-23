namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNotFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotFalse();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not False,
				                  but found False
				                  at Expect.That(subject).Should().IsNotFalse()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotFalse();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotFalse();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
