namespace Testably.Expectations.Tests.That.Exceptions;

public sealed partial class ExceptionShould
{
	public class HaveInnerExceptionTests
	{
		[Fact]
		public async Task FailsWhenInnerExceptionHasCorrectMessageButUnexpectedType()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).Should()
					.HaveInner<CustomException>(e => e.HaveMessage("inner"));

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have an inner CustomException which should have Message equal to "inner",
				             but found an Exception:
				               inner
				             at Expect.That(subject).Should().HaveInner<CustomException>(e => e.HaveMessage("inner"))
				             """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionHasCorrectTypeButUnexpectedMessage()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).Should()
					.HaveInner<CustomException>(e => e.HaveMessage("some other message"));

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have an inner CustomException which should have Message equal to "some other message",
				             but found "inner" which differs at index 0:
				                ↓ (actual)
				               "inner"
				               "some other message"
				                ↑ (expected)
				             at Expect.That(subject).Should().HaveInner<CustomException>(e => e.HaveMessage("some other message"))
				             """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionHasUnexpectedMessage()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).Should()
					.HaveInnerException(e => e.HaveMessage("some other message"));

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have an inner exception which should have Message equal to "some other message",
				             but found "inner" which differs at index 0:
				                ↓ (actual)
				               "inner"
				               "some other message"
				                ↑ (expected)
				             at Expect.That(subject).Should().HaveInnerException(e => e.HaveMessage("some other message"))
				             """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionIsNotOfTheExpectedType()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).Should().HaveInner<CustomException>();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have an inner CustomException,
				             but found an Exception:
				               inner
				             at Expect.That(subject).Should().HaveInner<CustomException>()
				             """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionIsNotSet()
		{
			Exception subject = new("outer");

			async Task Act()
				=> await Expect.That(subject).Should().HaveInnerException();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have an inner exception,
				             but found <null>
				             at Expect.That(subject).Should().HaveInnerException()
				             """);
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionHasCorrectMessage()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).Should()
					.HaveInnerException(e => e.HaveMessage("inner"));

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionHasCorrectTypeAndMessage()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).Should()
					.HaveInner<CustomException>(e => e.HaveMessage("inner"));

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionIsSet()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).Should().HaveInnerException();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionMeetsType()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).Should().HaveInner<CustomException>();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
