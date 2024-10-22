namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsNullTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is <null>,
				                  but found False
				                  at Expect.That(subject).IsNull()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is <null>,
				                  but found True
				                  at Expect.That(subject).IsNull()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
