namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class DelegateShould
{
	public sealed class ThrowTests
	{
		[Fact]
		public async Task WhenAwaited_ShouldReturnException()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			CustomException result = await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WithoutThrownException_ShouldFail()
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
				.WithMessage(expectedMessage);
		}

		[Fact]
		public async Task WithThrownExactException_ShouldSucceed()
		{
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WithThrownOtherException_ShouldFail()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          throw a CustomException,
			                          but it did throw an OtherException:
			                            {nameof(WithThrownOtherException_ShouldFail)}
			                          at Expect.That(action).Should().Throw<CustomException>()
			                          """;
			Exception exception = CreateOtherException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().ThrowException()
				.WithMessage(expectedMessage);
		}

		[Fact]
		public async Task WithThrownSubtypeException_ShouldSucceed()
		{
			Exception exception = CreateSubCustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await Expect.That(action).Should().Throw<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WithThrownSupertypeException_ShouldFail()
		{
			string expectedMessage = $"""
			                          Expected action to
			                          throw a SubCustomException,
			                          but it did throw a CustomException:
			                            {nameof(WithThrownSupertypeException_ShouldFail)}
			                          at Expect.That(action).Should().Throw<SubCustomException>()
			                          """;
			Exception exception = CreateCustomException();
			Action action = () => throw exception;

			async Task<SubCustomException> Act()
				=> await Expect.That(action).Should().Throw<SubCustomException>();

			await Expect.That(Act).Should().ThrowException()
				.WithMessage(expectedMessage);
		}
	}
}
