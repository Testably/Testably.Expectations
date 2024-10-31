namespace Testably.Expectations.Tests.ThatTests.Booleans;

public sealed partial class BoolShould
{
	public sealed class BeFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldSucceed()
		{
			bool subject = false;

			async Task Act()
				=> await That(subject).Should().BeFalse();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool subject = true;

			async Task Act()
				=> await That(subject).Should().BeFalse();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be False,
				             but found True
				             at Expect.That(subject).Should().BeFalse()
				             """);
		}
	}
}
