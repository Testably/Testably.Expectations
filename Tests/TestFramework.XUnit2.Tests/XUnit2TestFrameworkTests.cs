using System;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests;

public sealed class XUnit2TestFrameworkTests
{
	[Fact]
	public void WhenUsingXunit2AsTestFramework_ShouldThrowXunitException()
	{
		Action act = () => Expect.That(true, Should.Be.False());

		Expect.That(act, Should.Throw.TypeOf<XunitException>());
	}
}
