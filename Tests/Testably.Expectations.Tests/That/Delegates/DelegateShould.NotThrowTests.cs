namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class DelegateShould
{
	public sealed class NotThrowTests
	{
		[Fact]
		public async Task Fails_For_Code_With_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          not throw any exception,
			                          but it did throw a CustomException:
			                            {nameof(Fails_For_Code_With_Exceptions)}
			                          at Expect.That(action).Should().NotThrow()
			                          """;
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task Act()
				=> await Expect.That(action).Should().NotThrow();

			await Expect.That(Act).Should().ThrowException()
				.WithMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Awaited_Result()
		{
			int value = 42;
			Func<int> action = () => value;

			int result = await Expect.That(action).Should().NotThrow();
			await Expect.That(result).Should().Be(value);
		}

		[Fact]
		public async Task Succeeds_For_Code_Without_Exceptions()
		{
			Action action = () => { };

			async Task Act()
				=> await Expect.That(action).Should().NotThrow();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
