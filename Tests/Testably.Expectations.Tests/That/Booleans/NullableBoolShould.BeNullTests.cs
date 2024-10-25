namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class NullableBoolShould
{
	public sealed class BeNullTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  be <null>,
				                  but found False
				                  at Expect.That(subject).Should().BeNull()
				                  """);
		}

		[Fact]
		public async Task WhenNull_ShouldSucceed()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFail()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  be <null>,
				                  but found True
				                  at Expect.That(subject).Should().BeNull()
				                  """);
		}
	}

	public sealed class NotBeNullTests
	{
		[Fact]
		public async Task WhenFalse_ShouldSucceed()
		{
			bool? subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNull_ShouldFail()
		{
			bool? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not be <null>,
				                  but found <null>
				                  at Expect.That(subject).Should().NotBeNull()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool? subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
