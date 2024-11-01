namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithRecursiveInnerExceptionsTests
	{
		[Fact]
		public async Task WhenAwaited_WithExpectations_ShouldReturnThrownException()
		{
			Exception exception = new("outer", new Exception("inner"));

			Exception? result = await That(() => throw exception)
				.Should().ThrowException().WithRecursiveInnerExceptions(
					e => e.None().Satisfy(_ => false));

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenInnerExceptionDoesNotMatch_ShouldFail()
		{
			Action action = () => throw new Exception("", new Exception("inner"));

			async Task Act()
				=> await That(action).Should().ThrowException().WithRecursiveInnerExceptions(
					e => e.All().Satisfy(_ => false));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected action to
				             throw an Exception with recursive inner exceptions which all satisfy "_ => false",
				             but not all did
				             at Expect.That(action).Should().ThrowException().WithRecursiveInnerExceptions(e => e.All().Satisfy(_ => false))
				             """);
		}

		[Fact]
		public async Task WhenNoInnerExceptionIsPresent_ShouldNotFailDirectly()
		{
			Action action = () => throw new Exception();

			async Task Act()
				=> await That(action).Should().ThrowException().WithRecursiveInnerExceptions(
					e => e.All().Satisfy(_ => false));

			await That(Act).Should().NotThrow();
		}
	}
}
