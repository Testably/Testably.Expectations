namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithInnerTests
	{
		[Fact]
		public async Task WhenAwaited_WithExpectations_ShouldReturnThrownException()
		{
			Exception exception = new CustomException("outer", new CustomException("inner"));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithInner<CustomException>(
					e => e.HaveMessage("inner"));

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenAwaited_WithoutExpectations_ShouldReturnThrownException()
		{
			Exception exception = new CustomException("outer", new CustomException("inner"));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithInner<CustomException>();

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenInnerExceptionIsPresent_ShouldSucceed()
		{
			Action action = () => throw new CustomException("outer", new CustomException("inner"));

			async Task Act()
				=> await That(action).Should().ThrowException().WithInner<CustomException>();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNoInnerExceptionIsPresent_ShouldFail()
		{
			string actual = "actual text";
			Action action = () => throw new CustomException(actual);

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
