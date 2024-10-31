namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithInnerExceptionTests
	{
		[Fact]
		public async Task WhenAwaited_WithExpectations_ShouldReturnThrownException()
		{
			Exception exception = new("outer", new Exception("inner"));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithInnerException(
					e => e.HaveMessage("inner"));

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenAwaited_WithoutExpectations_ShouldReturnThrownException()
		{
			Exception exception = new("outer", new Exception("inner"));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithInnerException();

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenInnerExceptionIsPresent_ShouldSucceed()
		{
			Action action = () => throw new Exception("outer", new Exception("inner"));

			async Task Act()
				=> await That(action).Should().ThrowException().WithInnerException();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNoInnerExceptionIsPresent_ShouldFail()
		{
			string actual = "actual text";
			Action action = () => throw new Exception(actual);

			async Task Act()
				=> await That(action).Should().ThrowException().WithInnerException();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected action to
				             throw an Exception with an inner exception,
				             but found <null>
				             at Expect.That(action).Should().ThrowException().WithInnerException()
				             """);
		}
	}
}
