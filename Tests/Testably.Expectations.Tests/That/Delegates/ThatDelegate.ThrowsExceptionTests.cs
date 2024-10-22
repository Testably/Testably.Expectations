namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class ThatDelegate
{
	public sealed class ThrowsExceptionTests
	{
		[Fact]
		public async Task Fails_For_Code_Without_Exceptions()
		{
			string expectedMessage = """
			                         Expected that action
			                         throws an Exception,
			                         but it did not
			                         at Expect.That(action).ThrowsException()
			                         """;
			Action action = () => { };

			async Task<Exception> Act()
				=> await Expect.That(action).ThrowsException();

			await Expect.That(Act).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Exception result = await Expect.That(action).ThrowsException();

			await Expect.That(result).IsSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Exceptions()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<Exception> Act()
				=> await Expect.That(action).ThrowsException();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
