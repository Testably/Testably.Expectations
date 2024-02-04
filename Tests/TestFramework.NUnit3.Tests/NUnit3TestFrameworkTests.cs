using NUnit.Framework;
using System;

namespace Testably.Expectations.Tests;

public sealed class NUnit3TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit3AsTestFramework_ShouldThrowAssertionException()
	{
		Action act = () => Expect.That(true, Is.False);

		Expect.That(act, Throws.TypeOf<AssertionException>());
	}
}
