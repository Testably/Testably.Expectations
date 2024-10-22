namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNotFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).IsNotFalse();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not False,
				                  but found False
				                  at Expect.That(subject).IsNotFalse()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNotFalse();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).IsNotFalse();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
