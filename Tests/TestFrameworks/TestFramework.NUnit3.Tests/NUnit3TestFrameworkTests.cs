using NUnit.Framework;
using Testably.Expectations;

namespace TestFramework.NUnit3.Tests;

public sealed class NUnit3TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit3AsTestFramework_ShouldThrowAssertionException()
	{
		void Act()
			=> Expect.That(true, Should.Be.False());

		Expect.That(Act, Should.Throw.TypeOf<AssertionException>());
	}
}
