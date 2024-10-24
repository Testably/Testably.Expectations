namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class ThatDelegateShould
{
	public sealed class ThrowExactlyTests
	{
		[Fact]
		public async Task Fails_For_Code_With_Other_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          throw exactly a CustomException,
			                          but it did throw an OtherException:
			                            {nameof(Fails_For_Code_With_Other_Exceptions)}
			                          at Expect.That(action).Should().ThrowExactly<CustomException>()
			                          """;
			Exception exception = CreateOtherException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().ThrowExactly<CustomException>();

			await Expect.That(Act).Should().ThrowException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_With_Subtype_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          throw exactly a CustomException,
			                          but it did throw a SubCustomException:
			                            {nameof(Fails_For_Code_With_Subtype_Exceptions)}
			                          at Expect.That(action).Should().ThrowExactly<CustomException>()
			                          """;
			Exception exception = CreateSubCustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().ThrowExactly<CustomException>();

			await Expect.That(Act).Should().ThrowException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_Without_Exceptions()
		{
			string expectedMessage = """
			                         Expected action to
			                         throw exactly a CustomException,
			                         but it did not
			                         at Expect.That(action).Should().ThrowExactly<CustomException>()
			                         """;
			Action action = () => { };

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().ThrowExactly<CustomException>();

			await Expect.That(Act).Should().ThrowException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			CustomException result = await Expect.That(action).Should().ThrowExactly<CustomException>();

			await Expect.That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Correct_Exception()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().ThrowExactly<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
