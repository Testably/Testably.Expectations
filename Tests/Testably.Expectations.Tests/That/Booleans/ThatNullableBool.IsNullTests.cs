namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNullTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is <null>,
				                  but found False
				                  at Expect.That(subject).Should().IsNull()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is <null>,
				                  but found True
				                  at Expect.That(subject).Should().IsNull()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
