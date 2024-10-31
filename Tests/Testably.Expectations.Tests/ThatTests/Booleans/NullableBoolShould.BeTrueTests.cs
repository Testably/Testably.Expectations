namespace Testably.Expectations.Tests.ThatTests.Booleans;

public sealed partial class NullableBoolShould
{
	public sealed class BeTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await That(subject).Should().BeTrue();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be True,
				             but found False
				             at Expect.That(subject).Should().BeTrue()
				             """);
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await That(subject).Should().BeTrue();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be True,
				             but found <null>
				             at Expect.That(subject).Should().BeTrue()
				             """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await That(subject).Should().BeTrue();

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await That(subject).Should().NotBeTrue();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await That(subject).Should().NotBeTrue();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

			async Task Act()
				=> await That(subject).Should().NotBeTrue();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be True,
				             but found True
				             at Expect.That(subject).Should().NotBeTrue()
				             """);
		}
	}
}
