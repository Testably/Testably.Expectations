namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithInnerTests
	{
		[Theory]
		[AutoData]
		public async Task WhenAwaited_WithExpectations_ShouldReturnThrownException(string message)
		{
			Exception exception = new OuterException(innerException: new CustomException(message));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithInner<CustomException>(
					e => e.HaveMessage(message));

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenAwaited_WithoutExpectations_ShouldReturnThrownException()
		{
			Exception exception = new OuterException(innerException: new CustomException());

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithInner<CustomException>();

			await That(result).Should().BeSameAs(exception);
		}

		[Theory]
		[AutoData]
		public async Task WhenInnerExceptionHasSuperType_ShouldFail(string message)
		{
			Action action = ()
				=> throw new OuterException(innerException: new CustomException(message));

			async Task Act()
				=> await That(action).Should().ThrowException().WithInner<SubCustomException>();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected action to
				              throw an Exception with an inner SubCustomException,
				              but found a CustomException:
				                {message}
				              at Expect.That(action).Should().ThrowException().WithInner<SubCustomException>()
				              """);
		}

		[Theory]
		[AutoData]
		public async Task WhenInnerExceptionHasWrongType_ShouldFail(string message)
		{
			Action action = ()
				=> throw new OuterException(innerException: new OtherException(message));

			async Task Act()
				=> await That(action).Should().ThrowException().WithInner<CustomException>();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected action to
				              throw an Exception with an inner CustomException,
				              but found an OtherException:
				                {message}
				              at Expect.That(action).Should().ThrowException().WithInner<CustomException>()
				              """);
		}

		[Fact]
		public async Task WhenInnerExceptionIsPresent_ShouldSucceed()
		{
			Action action = () => throw new OuterException(innerException: new CustomException());

			async Task Act()
				=> await That(action).Should().ThrowException().WithInner<CustomException>();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenInnerExceptionIsSubType_ShouldSucceed()
		{
			Action action = ()
				=> throw new OuterException(innerException: new SubCustomException());

			async Task Act()
				=> await That(action).Should().ThrowException().WithInner<CustomException>();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNoInnerExceptionIsPresent_ShouldFail()
		{
			Action action = () => throw new OuterException();

			async Task Act()
				=> await That(action).Should().ThrowException().WithInner<CustomException>();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected action to
				             throw an Exception with an inner CustomException,
				             but found <null>
				             at Expect.That(action).Should().ThrowException().WithInner<CustomException>()
				             """);
		}
	}
}
