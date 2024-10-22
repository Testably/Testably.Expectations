namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldSucceed()
		{
			bool subject = false;

			async Task Act()
				=> await Expect.That(subject).IsFalse();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool subject = true;

			async Task Act()
				=> await Expect.That(subject).IsFalse();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is False,
				                  but found True
				                  at Expect.That(subject).IsFalse()
				                  """);
		}
	}
}
