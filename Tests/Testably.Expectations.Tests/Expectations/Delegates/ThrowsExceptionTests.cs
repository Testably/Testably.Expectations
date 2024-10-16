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
}
