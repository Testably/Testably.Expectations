using NUnit.Framework;
using Testably.Expectations;

namespace TestFramework.NUnit4.Tests;

public sealed class NUnit4TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit4AsTestFramework_ShouldThrowAssertionException()
	{
		void Act()
			=> Expect.That(true).IsFalse();

		Expect.That(Act).Throws<AssertionException>();
	}
}
