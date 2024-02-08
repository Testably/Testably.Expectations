using System;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests;

public sealed class XUnit2TestFrameworkTests
{
	[Fact]
	public void WhenUsingXunit2AsTestFramework_ShouldThrowXunitException()
	{
		void Act()
			=> Expect.That(true, Should.Be.False());

		Expect.That(Act, Should.Throw.TypeOf<XunitException>());
	}
}
