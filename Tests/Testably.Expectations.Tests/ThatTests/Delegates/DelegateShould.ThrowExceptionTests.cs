namespace Testably.Expectations.Tests.ThatTests.Delegates;

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
				=> await That(action).Should().ThrowException();

			await That(Act).Should().ThrowException()
				.WithMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Exception result = await That(action).Should().ThrowException();

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Exceptions()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<Exception> Act()
				=> await That(action).Should().ThrowException();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenAwaited_ShouldReturnThrownException()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Exception result = await That(action).Should().ThrowException();

			await That(result).Should().BeSameAs(exception);
		}
	}
}
