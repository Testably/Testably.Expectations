namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class BoolShould
{
	public sealed class BeFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldSucceed()
		{
			bool subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().BeFalse();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().BeFalse();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be False,
				                  but found True
				                  at Expect.That(subject).Should().BeFalse()
				                  """);
		}
	}
}
