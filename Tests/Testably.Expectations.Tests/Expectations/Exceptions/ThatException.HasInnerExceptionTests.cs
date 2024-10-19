using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Exceptions;

public sealed partial class ThatException
{
	public class HasInnerExceptionTests
	{
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

		private class CustomException : Exception
		{
			public CustomException(string message, Exception? innerException = null)
				: base(message, innerException)
			{

			}

			public string Value => "Foo!";
		}
	}
}
