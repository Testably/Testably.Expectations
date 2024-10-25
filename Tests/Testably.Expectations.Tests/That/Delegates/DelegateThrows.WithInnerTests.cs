namespace Testably.Expectations.Tests.That.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithInnerTests
	{
		[Fact]
		public async Task WhenInnerExceptionIsPresent_ShouldSucceed()
		{
			Action action = () => throw new CustomException("outer", new CustomException("inner"));

			async Task Act()
				=> await Expect.That(action).Should().ThrowException().WithInner<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenNoInnerExceptionIsPresent_ShouldFail()
		{
			string actual = "actual text";
			Action action = () => throw new CustomException(actual);

			async Task Act()
				=> await Expect.That(action).Should().ThrowException().WithInner<CustomException>();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected action to
				             throw an Exception with an inner CustomException,
				             but found <null>
				             at Expect.That(action).Should().ThrowException().WithMessage(expected)
				             """);
		}
	}
}
