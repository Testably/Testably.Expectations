namespace Testably.Expectations.Tests.That.Exceptions;

public sealed partial class ThatException
{
	public class HasInnerExceptionTests
	{
		[Fact]
		public async Task FailsWhenInnerExceptionHasCorrectMessageButUnexpectedType()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).HasInner<CustomException>(e => e.HasMessage("inner"));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has an inner CustomException which has Message equal to "inner",
				                  but found an Exception:
				                    inner
				                  at Expect.That(subject).HasInner<CustomException>(e => e.HasMessage("inner"))
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionHasCorrectTypeButUnexpectedMessage()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject)
					.HasInner<CustomException>(e => e.HasMessage("some other message"));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has an inner CustomException which has Message equal to "some other message",
				                  but found "inner" which differs at index 0:
				                     ↓ (actual)
				                    "inner"
				                    "some other message"
				                     ↑ (expected)
				                  at Expect.That(subject).HasInner<CustomException>(e => e.HasMessage("some other message"))
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionHasUnexpectedMessage()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject)
					.HasInnerException(e => e.HasMessage("some other message"));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has an inner exception which has Message equal to "some other message",
				                  but found "inner" which differs at index 0:
				                     ↓ (actual)
				                    "inner"
				                    "some other message"
				                     ↑ (expected)
				                  at Expect.That(subject).HasInnerException(e => e.HasMessage("some other message"))
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionIsNotOfTheExpectedType()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).HasInner<CustomException>();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has an inner CustomException,
				                  but found an Exception:
				                    inner
				                  at Expect.That(subject).HasInner<CustomException>()
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionIsNotSet()
		{
			Exception subject = new("outer");

			async Task Act()
				=> await Expect.That(subject).HasInnerException();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has an inner exception,
				                  but it did not
				                  at Expect.That(subject).HasInnerException()
				                  """);
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionHasCorrectMessage()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).HasInnerException(e => e.HasMessage("inner"));

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionHasCorrectTypeAndMessage()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).HasInner<CustomException>(e => e.HasMessage("inner"));

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionIsSet()
		{
			Exception subject = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(subject).HasInnerException();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionMeetsType()
		{
			Exception subject = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(subject).HasInner<CustomException>();

			await Expect.That(Act).DoesNotThrow();
		}

		private class CustomException(string message, Exception? innerException = null)
			: Exception(message, innerException);
	}
}
