using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Delegates;

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
			                          at Expect.That(action).DoesNotThrow()
			                          """;
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Func<Task> sut = async ()
				=> await Expect.That(action).DoesNotThrow();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Awaited_Result()
		{
			int value = 42;
			Func<int> action = () => value;

			int result = await Expect.That(action).DoesNotThrow();
			await Expect.That(result).Is(value);
		}

		[Fact]
		public async Task Succeeds_For_Code_Without_Exceptions()
		{
			Action action = () => { };

			Func<Task> sut = async ()
				=> await Expect.That(action).DoesNotThrow();

			await Expect.That(sut).DoesNotThrow();
		}
	}
}
