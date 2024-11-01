namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateShould
{
	public sealed class ThrowExactlyTests
	{
		[Theory]
		[AutoData]
		public async Task WhenAwaited_ShouldReturnThrownException(string value)
		{
			Exception exception = new CustomException { Value = value };
			Action action = () => throw exception;

			CustomException result =
				await That(action).Should().ThrowExactly<CustomException>();

			await That(result.Value).Should().Be(value);
			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenCorrectExceptionTypeIsThrown_ShouldSucceed()
		{
			Exception exception = new CustomException();
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await That(action).Should().ThrowExactly<CustomException>();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNoExceptionIsThrown_ShouldFail()
		{
			Action action = () => { };

			async Task<CustomException> Act()
				=> await That(action).Should().ThrowExactly<CustomException>();

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected action to
				             throw exactly a CustomException,
				             but it did not
				             at Expect.That(action).Should().ThrowExactly<CustomException>()
				             """);
		}

		[Theory]
		[AutoData]
		public async Task WhenOtherExceptionIsThrown_ShouldFail(string message)
		{
			Exception exception = new OtherException(message);
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await That(action).Should().ThrowExactly<CustomException>();

			await That(Act).Should().ThrowException()
				.WithMessage($"""
				              Expected action to
				              throw exactly a CustomException,
				              but it did throw an OtherException:
				                {message}
				              at Expect.That(action).Should().ThrowExactly<CustomException>()
				              """);
		}

		[Theory]
		[AutoData]
		public async Task WhenSubCustomExceptionIsThrown_ShouldFail(string message)
		{
			Exception exception = new SubCustomException(message);
			Action action = () => throw exception;

			async Task<CustomException> Act()
				=> await That(action).Should().ThrowExactly<CustomException>();

			await That(Act).Should().ThrowException()
				.WithMessage($"""
				              Expected action to
				              throw exactly a CustomException,
				              but it did throw a SubCustomException:
				                {message}
				              at Expect.That(action).Should().ThrowExactly<CustomException>()
				              """);
		}
	}
}
