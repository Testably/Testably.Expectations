using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Expectations.Delegates;

public sealed partial class ThatDelegate
{
    public sealed class ThrowsExceptionTests
    {
        [Fact]
        public async Task Fails_For_Code_Without_Exceptions()
        {
            var expectedMessage = """
                                  Expected that action
                                  throws an Exception,
                                  but it did not
                                  at Expect.That(action).ThrowsException()
                                  """;
            var action = () => { };

            var sut = async ()
                => await That(action).ThrowsException();

            await That(sut).ThrowsException()
                .Which.HasMessage(expectedMessage);
        }

        [Fact]
        public async Task Returns_Exception_When_Awaited()
        {
            Exception exception = CreateCustomException();
            Action action = () => throw exception;

            var result = await That(action).ThrowsException();

            await That(result).IsSameAs(exception);
		}

        [Fact]
        public async Task Succeeds_For_Code_With_Exceptions()
        {
            Exception exception = CreateCustomException();
            Action action = () => throw exception;

            var sut = async ()
                => await That(action).ThrowsException();

            await That(sut).DoesNotThrow();
        }
    }
}
