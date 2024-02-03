using System;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests;

public sealed class XUnit2TestFrameworkTests
{
	[Fact]
	public void WhenUsingXunitAsTestFramework_ShouldThrowXunitException()
	{
		Action act = () => Expect.That(true, Is.False);

		var exception = Assert.Throws<XunitException>(act);
	}
}
