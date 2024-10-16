using AutoFixture.Xunit2;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Delegates;

public class ThrowsExceptionTests
{
	[Theory]
	[AutoData]
	public async Task FailsWhenExceptionHasDifferentMessage(string actual, string expected)
	{
		Action action = () => throw new Exception(actual);

		async Task Act()
			=> await Expect.That(action).ThrowsException().Which.HasMessage(expected);

		XunitException exception = await Assert.ThrowsAsync<XunitException>(Act);
		Assert.Equal($"""
		              Expected that action
		              throws an Exception which has Message equal to "{expected}",
		              but found "{actual}" which differs at index 0:
		                  ↓
		                 "{actual}"
		                 "{expected}"
		                  ↑
		              at Expect.That(action).ThrowsException().Which.HasMessage(expected)
		              """, exception.Message);
	}

	[Fact]
	public async Task FailsWhenNoExceptionIsThrown()
	{
		Action action = () => { };

		async Task Act()
			=> await Expect.That(action).ThrowsException();

		XunitException exception = await Assert.ThrowsAsync<XunitException>(Act);
		Assert.Equal("""
		             Expected that action
		             throws an Exception,
		             but it did not
		             at Expect.That(action).ThrowsException()
		             """, exception.Message);
	}

	[Fact]
	public async Task SucceedsWhenExceptionIsThrown()
	{
		Action action = () => throw new Exception("foo");

		async Task Act()
			=> await Expect.That(action).ThrowsException();

		await Act();
	}

	[Theory]
	[AutoData]
	public async Task SucceedsWhenThrownExceptionHasSameMessage(string message)
	{
		Action action = () => throw new Exception(message);

		async Task Act()
			=> await Expect.That(action).ThrowsException().Which.HasMessage(message);

		await Act();
	}
}
