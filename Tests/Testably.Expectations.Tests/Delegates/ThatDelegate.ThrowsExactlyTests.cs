using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Delegates;

public sealed partial class ThatDelegate
{
	public sealed class ThrowsExactlyTests
	{
		[Fact]
		public async Task Fails_For_Code_With_Other_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected that action
			                          throws exactly a CustomException,
			                          but it did throw an OtherException:
			                            {nameof(Fails_For_Code_With_Other_Exceptions)}
			                          at Expect.That(action).ThrowsExactly<CustomException>()
			                          """;
			Exception exception = CreateOtherException();
			Action action = () => throw exception;

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).ThrowsExactly<CustomException>();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_With_Subtype_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected that action
			                          throws exactly a CustomException,
			                          but it did throw a SubCustomException:
			                            {nameof(Fails_For_Code_With_Subtype_Exceptions)}
			                          at Expect.That(action).ThrowsExactly<CustomException>()
			                          """;
			Exception exception = CreateSubCustomException();
			Action action = () => throw exception;

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).ThrowsExactly<CustomException>();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_Without_Exceptions()
		{
			string expectedMessage = """
			                         Expected that action
			                         throws exactly a CustomException,
			                         but it did not
			                         at Expect.That(action).ThrowsExactly<CustomException>()
			                         """;
			Action action = () => { };

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).ThrowsExactly<CustomException>();

			await Expect.That(sut).ThrowsException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			CustomException result = await Expect.That(action).ThrowsExactly<CustomException>();

			await Expect.That(result).IsSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Correct_Exception()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			Func<Task<CustomException>> sut = async ()
				=> await Expect.That(action).ThrowsExactly<CustomException>();

			await Expect.That(sut).DoesNotThrow();
		}
	}
}
