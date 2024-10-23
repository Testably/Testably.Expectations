namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class ThatDelegate
{
	public sealed class OnlyIfTests
	{
		[Fact]
		public async Task ShouldSupportChainedConstraints()
		{
			Action action = () => { };

			await Expect.That(action).Should().ThrowsException()
				.OnlyIf(false)
				.Which.HasMessage("foo");
		}

		[Fact]
		public async Task ShouldSupportChainedConstraintsForTypedException()
		{
			Action action = () => { };

			await Expect.That(action).Should().Throws<ArgumentException>()
				.OnlyIf(false)
				.Which.HasMessage("foo");
		}

		[Fact]
		public async Task WhenFalse_ShouldFailWhenAnExceptionWasThrown()
		{
			Exception exception = new("");
			Action action = () => throw exception;

			async Task Act()
				=> await Expect.That(action).Should().ThrowsException().OnlyIf(false);

			await Expect.That(Act).Should().ThrowsException()
				.Which.HasMessage("""
				                  Expected Act toion
				                  does not throw any exception,
				                  but it did throw an Exception
				                  at Expect.That(action).Should().ThrowsException().OnlyIf(false)
				                  """);
		}

		[Fact]
		public async Task WhenFalse_ShouldSucceedWhenNoExceptionWasThrown()
		{
			Action action = () => { };

			async Task Act()
				=> await Expect.That(action).Should().ThrowsException().OnlyIf(false);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenTrue_ShouldFailWhenNoExceptionWasThrow()
		{
			Action action = () => { };

			async Task Act()
				=> await Expect.That(action).Should().ThrowsException().OnlyIf(true);

			await Expect.That(Act).Should().ThrowsException()
				.Which.HasMessage("""
				                  Expected Act toion
				                  throws an Exception,
				                  but it did not
				                  at Expect.That(action).Should().ThrowsException().OnlyIf(true)
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceedWhenAnExceptionWasThrow()
		{
			Exception exception = new("");
			Action action = () => throw exception;

			async Task Act()
				=> await Expect.That(action).Should().ThrowsException().OnlyIf(true);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
