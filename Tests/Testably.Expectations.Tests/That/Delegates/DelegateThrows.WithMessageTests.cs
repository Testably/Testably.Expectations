namespace Testably.Expectations.Tests.That.Delegates;

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
				=> await Expect.That(action).Should().ThrowException().WithMessage(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
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

			CustomException result = await Expect.That(Act).Should().Throw<CustomException>()
				.WithInner<SubCustomException>(e1 => e1
					.HaveMessage("inner1").And
					.HaveInner<ArgumentException>(e2 => e2
						.HaveParamName("param2").And.HaveMessage("inner2*").AsWildcard()));

			await Expect.That(result).Should().BeSameAs(exception);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception subject = new(actual);

			async Task Act()
				=> await Expect.That(subject).Should().HaveMessage(actual);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
