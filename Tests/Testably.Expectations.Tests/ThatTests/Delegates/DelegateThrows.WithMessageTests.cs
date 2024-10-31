namespace Testably.Expectations.Tests.ThatTests.Delegates;

public sealed partial class DelegateThrows
{
	public sealed class WithMessageTests
	{
		[Fact]
		public async Task FailsForDifferentStrings()
		{
			string actual = "actual text";
			string expected = "expected other text";
			Action action = () => throw new Exception(actual);

			async Task Act()
				=> await That(action).Should().ThrowException().WithMessage(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected action to
				             throw an Exception with Message equal to "expected other text",
				             but found "actual text" which differs at index 0:
				                ↓ (actual)
				               "actual text"
				               "expected other text"
				                ↑ (expected)
				             at Expect.That(action).Should().ThrowException().WithMessage(expected)
				             """);
		}

		[Fact]
		public async Task ShouldSupportNestedChecks()
		{
			Exception exception = new CustomException("outer",
				new SubCustomException("inner1",
					new ArgumentException("inner2", "param2")));
			void Act() => throw exception;

			CustomException result = await That(Act).Should().Throw<CustomException>()
				.WithInnerException(e1 => e1
					.HaveMessage("inner1").And
					.HaveInner<ArgumentException>(e2 => e2
						.HaveParamName("param2").And.HaveMessage("inner2*").AsWildcard()));

			await That(result).Should().BeSameAs(exception);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception subject = new(actual);

			async Task Act()
				=> await That(subject).Should().HaveMessage(actual);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenAwaited_ShouldReturnThrownException()
		{
			Exception exception = new("outer", new Exception("inner"));

			Exception result = await That(() => throw exception)
				.Should().ThrowException().WithMessage("outer").AsWildcard();

			await That(result).Should().BeSameAs(exception);
		}
	}
}
