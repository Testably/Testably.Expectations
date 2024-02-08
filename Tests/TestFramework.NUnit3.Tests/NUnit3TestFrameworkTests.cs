using NUnit.Framework;
using System;

namespace Testably.Expectations.Tests;

public sealed class NUnit3TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit3AsTestFramework_ShouldThrowAssertionException()
	{
		Action act = () => Expect.That(true, Should.Be.False());

		Expect.That(act, Should.Throw.TypeOf<AssertionException>());
	}
}
