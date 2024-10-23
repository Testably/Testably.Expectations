namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNotTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotTrue();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotTrue();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotTrue();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not True,
				                  but found True
				                  at Expect.That(subject).Should().IsNotTrue()
				                  """);
		}
	}
}
