using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Expectations.Delegates;

public sealed partial class ThatDelegate
{
    public sealed class DoesNotThrowTests
    {
        [Fact]
        public async Task Fails_For_Code_With_Exceptions()
        {
            var expectedMessage = $"""
                                    Expected that action
                                    does not throw any exception,
                                    but it did throw a CustomException:
                                      {nameof(Fails_For_Code_With_Exceptions)}
                                    at Expect.That(action).DoesNotThrow()
                                    """;
            Exception exception = CreateCustomException();
            Action action = () => throw exception;

            var sut = async ()
                => await Expect.That(action).DoesNotThrow();

            await Expect.That(sut).ThrowsException()
                .Which.HasMessage(expectedMessage);
        }

        [Fact]
        public async Task Succeeds_For_Code_Without_Exceptions()
        {
            var action = () => { };

            var sut = async ()
                => await Expect.That(action).DoesNotThrow();

            await Expect.That(sut).DoesNotThrow();
        }

        [Fact]
        public async Task Returns_Awaited_Result()
        {
            var value = 42;
            var action = () => value;

            var result = await Expect.That(action).DoesNotThrow();
            await Expect.That(result).Is(value);
        }
    }
}
