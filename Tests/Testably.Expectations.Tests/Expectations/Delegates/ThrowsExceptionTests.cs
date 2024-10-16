using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Delegates;
public class ThrowsExceptionTests
{
	[Fact]
	public async Task FailsWhenNoExceptionIsThrown()
	{
		var action = () => { };
		async Task Act()
			=> await Expect.That(action).ThrowsException();

		var exception = await Assert.ThrowsAsync<XunitException>(Act);
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
		System.Action action = () => throw new System.Exception("foo");
		async Task Act()
			=> await Expect.That(action).ThrowsException();

		await Act();
	}

	[Theory]
	[AutoData]
	public async Task FailsWhenExceptionHasDifferentMessage(string actual, string expected)
	{
		System.Action action = () => throw new System.Exception(actual);
		async Task Act()
			=> await Expect.That(action).ThrowsException().Which.HasMessage(expected);

		var exception = await Assert.ThrowsAsync<XunitException>(Act);
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

	[Theory]
	[AutoData]
	public async Task SucceedsWhenThrownExceptionHasSameMessage(string message)
	{
		System.Action action = () => throw new System.Exception(message);
		async Task Act()
			=> await Expect.That(action).ThrowsException().Which.HasMessage(message);

		await Act();
	}
}
