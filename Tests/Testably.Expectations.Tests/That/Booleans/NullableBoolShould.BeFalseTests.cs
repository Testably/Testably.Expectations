namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class NullableBoolShould
{
	public sealed class BeFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldSucceed()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().BeFalse();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeFalse();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  be False,
				                  but found <null>
				                  at Expect.That(subject).Should().BeFalse()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

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

	public sealed class NotBeFalseTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeFalse();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  not be False,
				                  but found False
				                  at Expect.That(subject).Should().NotBeFalse()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeFalse();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeFalse();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
