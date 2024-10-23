namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().IsTrue();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is True,
				                  but found False
				                  at Expect.That(subject).Should().IsTrue()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsTrue();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is True,
				                  but found <null>
				                  at Expect.That(subject).Should().IsTrue()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().IsTrue();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
