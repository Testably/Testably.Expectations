namespace Testably.Expectations.Tests.ThatTests.Numbers;

public sealed partial class NumberShould
{
	public sealed class Be
	{
		public sealed class WithinTests
		{
			[Fact]
			public async Task WhenInsideTolerance_ShouldSucceed()
			{
				int subject = 12;
				int expected = 11;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().NotThrow();
			}

			[Fact]
			public async Task WhenOutsideTolerance_ShouldFail()
			{
				int subject = 12;
				int expected = 10;

				async Task Act()
					=> await That(subject).Should().Be(expected).Within(1);

				await That(Act).Should().Throw<XunitException>()
					.WithMessage("""
					             Expected subject to
					             be 10 ± 1,
					             but found 12
					             at Expect.That(subject).Should().Be(expected).Within(1)
					             """);
			}
		}
	}
}
