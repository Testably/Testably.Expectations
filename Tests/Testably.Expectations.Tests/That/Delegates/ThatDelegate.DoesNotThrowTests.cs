namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class ThatDelegate
{
	public sealed class DoesNotThrowTests
	{
		[Fact]
		public async Task Fails_For_Code_With_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected that action
			                          does not throw any exception,
			                          but it did throw a CustomException:
			                            {nameof(Fails_For_Code_With_Exceptions)}
			                          at Expect.That(action).Should().DoesNotThrow()
			                          """;
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task Act()
				=> await Expect.That(action).Should().DoesNotThrow();

			await Expect.That(Act).Should().ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Awaited_Result()
		{
			int value = 42;
			Func<int> action = () => value;

			int result = await Expect.That(action).Should().DoesNotThrow();
			await Expect.That(result).Should().Is(value);
		}

		[Fact]
		public async Task Succeeds_For_Code_Without_Exceptions()
		{
			Action action = () => { };

			async Task Act()
				=> await Expect.That(action).Should().DoesNotThrow();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
