namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class BoolShould
{
	public sealed class BeTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().BeTrue();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be True,
				             but found False
				             at Expect.That(subject).Should().BeTrue()
				             """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().BeTrue();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
