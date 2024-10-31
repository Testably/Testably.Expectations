namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithRecursiveInnerExceptionsTests
	{
		[Fact]
		public async Task WhenAwaited_WithExpectations_ShouldReturnThrownException()
		{
			Exception exception = new("outer", new Exception("inner"));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithRecursiveInnerExceptions(
					e => e.None().Satisfy(e => false));

			await That(result).Should().BeSameAs(exception);
		}

		[Fact]
		public async Task WhenNoInnerExceptionIsPresent_ShouldFail()
		{
			string actual = "actual text";
			Action action = () => throw new Exception(actual, new Exception("inner"));

			async Task Act()
				=> await That(action).Should().ThrowException().WithRecursiveInnerExceptions(e => e.All().Satisfy(_ => false));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected action to
				             throw an Exception with recursive inner exceptions which all satisfy "_ => false"
				             but not all did
				             at Expect.That(action).Should().ThrowException().WithRecursiveInnerExceptions(e => e.None().Satisfy(_ => true))
				             """);
		}
	}
}
