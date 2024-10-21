namespace Testably.Expectations.Tests.Primitives.Exceptions;

public sealed partial class ThatException
{
	public class HasInnerExceptionTests
	{
		[Fact]
		public async Task FailsWhenInnerExceptionHasCorrectMessageButUnexpectedType()
		{
			Exception sut = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(sut).HasInner<CustomException>(e => e.HasMessage("inner"));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has an inner CustomException which has Message equal to "inner",
				                  but found an Exception:
				                    inner
				                  at Expect.That(sut).HasInner<CustomException>(e => e.HasMessage("inner"))
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionHasCorrectTypeButUnexpectedMessage()
		{
			Exception sut = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(sut)
					.HasInner<CustomException>(e => e.HasMessage("some other message"));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has an inner CustomException which has Message equal to "some other message",
				                  but found "inner" which differs at index 0:
				                     ↓ (actual)
				                    "inner"
				                    "some other message"
				                     ↑ (expected)
				                  at Expect.That(sut).HasInner<CustomException>(e => e.HasMessage("some other message"))
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionHasUnexpectedMessage()
		{
			Exception sut = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(sut)
					.HasInnerException(e => e.HasMessage("some other message"));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has an inner exception which has Message equal to "some other message",
				                  but found "inner" which differs at index 0:
				                     ↓ (actual)
				                    "inner"
				                    "some other message"
				                     ↑ (expected)
				                  at Expect.That(sut).HasInnerException(e => e.HasMessage("some other message"))
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionIsNotOfTheExpectedType()
		{
			Exception sut = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(sut).HasInner<CustomException>();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has an inner CustomException,
				                  but found an Exception:
				                    inner
				                  at Expect.That(sut).HasInner<CustomException>()
				                  """);
		}

		[Fact]
		public async Task FailsWhenInnerExceptionIsNotSet()
		{
			Exception sut = new("outer");

			async Task Act()
				=> await Expect.That(sut).HasInnerException();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has an inner exception,
				                  but it did not
				                  at Expect.That(sut).HasInnerException()
				                  """);
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionHasCorrectMessage()
		{
			Exception sut = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(sut).HasInnerException(e => e.HasMessage("inner"));

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionHasCorrectTypeAndMessage()
		{
			Exception sut = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(sut).HasInner<CustomException>(e => e.HasMessage("inner"));

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionIsSet()
		{
			Exception sut = new("outer",
				new Exception("inner"));

			async Task Act()
				=> await Expect.That(sut).HasInnerException();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task SucceedsWhenInnerExceptionMeetsType()
		{
			Exception sut = new("outer",
				new CustomException("inner"));

			async Task Act()
				=> await Expect.That(sut).HasInner<CustomException>();

			await Expect.That(Act).DoesNotThrow();
		}

		private class CustomException(string message, Exception? innerException = null)
			: Exception(message, innerException);
	}
}
