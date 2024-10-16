using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Delegates;
public class DoesNotThrowTests
{
	[Fact]
	public async Task FailsWhenExceptionIsThrown()
	{
		System.Action action = () => throw new System.Exception("foo");
		async Task Act()
			=> await Expect.That(action).DoesNotThrow();

		var exception = await Assert.ThrowsAsync<XunitException>(Act);
		Assert.Equal("""
			Expected that action
			does not throw,
			but it did throw an Exception:
				foo
			at Expect.That(action).DoesNotThrow()
			""", exception.Message);
	}

	[Fact]
	public async Task SucceedsWhenNoExceptionIsThrown()
	{
		var action = () => { };
		async Task Act()
			=> await Expect.That(action).DoesNotThrow();

		await Act();
	}
}
