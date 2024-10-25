namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class DelegateShould
{
	public sealed class ThrowTests
	{
		[Fact]
		public async Task Fails_For_Code_With_Other_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          throw a CustomException,
			                          but it did throw an OtherException:
			                            {nameof(Fails_For_Code_With_Other_Exceptions)}
			                          at Expect.That(action).Should().Throw<CustomException>()
			                          """;
			Exception exception = CreateOtherException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().ThrowException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_With_Supertype_Exceptions()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          throw a SubCustomException,
			                          but it did throw a CustomException:
			                            {nameof(Fails_For_Code_With_Supertype_Exceptions)}
			                          at Expect.That(action).Should().Throw<SubCustomException>()
			                          """;
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<SubCustomException> Act()
				=> await Expect.That(action).Should().Throw<SubCustomException>();

			await Expect.That(Act).Should().ThrowException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Fails_For_Code_Without_Exceptions()
		{
			string expectedMessage = """
			                         Expected action to
			                         throw a CustomException,
			                         but it did not
			                         at Expect.That(action).Should().Throw<CustomException>()
			                         """;
			Action action = () => { };

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().ThrowException()
				.Which.HasMessage(expectedMessage);
		}

		[Fact]
		public async Task Returns_Exception_When_Awaited()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			CustomException result = await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Exact_Exceptions()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Succeeds_For_Code_With_Subtype_Exceptions()
		{
			Exception exception = CreateSubCustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
