using Testably.Expectations;
using Xunit;
using Xunit.Sdk;

namespace TestFramework.XUnit2.Tests;

public sealed class XUnit2TestFrameworkTests
{
	[Fact]
	public void WhenUsingXunit2AsTestFramework_ShouldThrowXunitException()
	{
		void Act()
			=> Expect.That(true).IsFalse();

		Expect.That(Act).Throws<XunitException>();
	}
}
