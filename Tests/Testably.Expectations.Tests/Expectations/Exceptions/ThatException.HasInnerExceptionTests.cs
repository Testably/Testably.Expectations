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
	}
}
