using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Expectations.Delegates;

public partial class DelegateExpectationTests
{
    public class ThrowsExactly
    {
        [Fact]
        public async Task Fails_For_Code_With_Other_Exceptions()
        {
            var expectedMessage = """
                                  Expected action to throw exactly a CustomException

                                  but an OtherException was thrown

                                  at Expect.That(action).ThrowsExactly<CustomException>()
                                  """;
            Exception exception = CreateOtherException();
            Action action = () => throw exception;

            var sut = async ()
                => await Expect.That(action).ThrowsExactly<CustomException>();

            await Expect.That(sut).ThrowsException()
                .Which.HasMessage(expectedMessage);
        }

        [Fact]
        public async Task Fails_For_Code_With_Subtype_Exceptions()
        {
            var expectedMessage = """
                                  Expected action to throw exactly a CustomException

                                  but a SubCustomException was thrown

                                  at Expect.That(action).ThrowsExactly<CustomException>()
                                  """;
            Exception exception = CreateSubCustomException();
            Action action = () => throw exception;

            var sut = async ()
                => await Expect.That(action).ThrowsExactly<CustomException>();

            await Expect.That(sut).ThrowsException()
                .Which.HasMessage(expectedMessage);
        }

        [Fact]
        public async Task Fails_For_Code_Without_Exceptions()
        {
            var expectedMessage = """
                                  Expected action to throw exactly a CustomException

                                  but none was thrown

                                  at Expect.That(action).ThrowsExactly<CustomException>()
                                  """;
            var action = () => { };

            var sut = async ()
                => await Expect.That(action).ThrowsExactly<CustomException>();

            await Expect.That(sut).ThrowsException()
                .Which.HasMessage(expectedMessage);
        }

        [Fact]
        public async Task Returns_Exception_When_Awaited()
        {
            Exception exception = CreateCustomException();
            Action action = () => throw exception;

            var result = await Expect.That(action).ThrowsExactly<CustomException>();

			Assert.Same(exception, result);
        }

        [Fact]
        public async Task Succeeds_For_Code_With_Correct_Exception()
        {
            Exception exception = CreateCustomException();
            Action action = () => throw exception;

            var sut = async ()
                => await Expect.That(action).ThrowsExactly<CustomException>();

            await Expect.That(sut).DoesNotThrow();
        }
    }
}
