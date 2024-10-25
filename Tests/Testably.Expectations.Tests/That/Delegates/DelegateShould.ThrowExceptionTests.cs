namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class DelegateShould
{
	public sealed class ThrowExceptionTests
	{
		[Fact]
		public async Task Fails_For_Code_Without_Exceptions()
		{
			string expectedMessage = """
			                         Expected action to
			                         throw an Exception,
			                         but it did not
			                         at Expect.That(action).Should().ThrowException()
			                         """;
			Action action = () => { };

			async Task<Exception> Act()
				=> await Expect.That(action).Should().ThrowException();

			await Expect.That(Act).Should().ThrowException()
				.Which.HaveMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Exception result = await Expect.That(action).Should().ThrowException();

			await Expect.That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Exceptions()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<Exception> Act()
				=> await Expect.That(action).Should().ThrowException();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
