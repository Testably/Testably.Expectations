namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool subject = false;

			async Task Act()
				=> await Expect.That(subject).IsTrue();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is True,
				                  but found False
				                  at Expect.That(subject).IsTrue()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool subject = true;

			async Task Act()
				=> await Expect.That(subject).IsTrue();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
