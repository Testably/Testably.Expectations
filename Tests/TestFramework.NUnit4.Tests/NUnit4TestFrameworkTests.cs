using NUnit.Framework;
using System;

namespace Testably.Expectations.Tests;

public sealed class NUnit4TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit4AsTestFramework_ShouldThrowAssertionException()
	{
		Action act = () => Expect.That(true, Is.False);

		Expect.That(act, Throws.TypeOf<AssertionException>());
	}
}
