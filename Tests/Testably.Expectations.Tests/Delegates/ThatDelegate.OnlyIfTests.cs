namespace Testably.Expectations.Tests.Delegates;

public sealed partial class ThatDelegate
{
	public sealed class OnlyIfTests
	{
		[Fact]
		public async Task WhenTrue_ShouldSucceedWhenAnExceptionWasThrow()
		{
			Exception exception = new("");
			Action action = () => throw exception;

			async Task Act()
				=> await Expect.That(action).ThrowsException().OnlyIf(true);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenFalse_ShouldSucceedWhenNoExceptionWasThrown()
		{
			Action action = () => { };

			async Task Act()
				=> await Expect.That(action).ThrowsException().OnlyIf(false);

			await Expect.That(Act).DoesNotThrow();
		}
		[Fact]
		public async Task WhenTrue_ShouldFailWhenNoExceptionWasThrow()
		{
			Action action = () => { };

			async Task Act()
				=> await Expect.That(action).ThrowsException().OnlyIf(true);

			await Expect.That(Act).ThrowsException()
				.Which.HasMessage("""
				                  Expected that action
				                  throws an Exception,
				                  but it did not
				                  at Expect.That(action).ThrowsException().OnlyIf(true)
				                  """);
		}

		[Fact]
		public async Task WhenFalse_ShouldFailWhenAnExceptionWasThrown()
		{
			Exception exception = new("");
			Action action = () => throw exception;

			async Task Act()
				=> await Expect.That(action).ThrowsException().OnlyIf(false);

			await Expect.That(Act).ThrowsException()
				.Which.HasMessage("""
				                  Expected that action
				                  does not throw any exception,
				                  but it did throw an Exception
				                  at Expect.That(action).ThrowsException().OnlyIf(false)
				                  """);
		}
	}
}
