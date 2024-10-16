using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Delegates;

public class DoesNotThrowTests
{
	[Fact]
	public async Task FailsWhenExceptionIsThrown()
	{
		Action action = () => throw new Exception("foo");

		async Task Act()
			=> await Expect.That(action).DoesNotThrow();

		XunitException exception = await Assert.ThrowsAsync<XunitException>(Act);
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
		Action action = () => { };

		async Task Act()
			=> await Expect.That(action).DoesNotThrow();

		await Act();
	}
}
