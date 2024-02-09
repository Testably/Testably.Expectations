using NUnit.Framework;
using System;
using Testably.Expectations.Expectations;

namespace Testably.Expectations.Tests;

public sealed class NUnit4TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit4AsTestFramework_ShouldThrowAssertionException()
	{
		void Act()
			=> Expect.That(true, Should.Be.False());

		Expect.That(Act, Should.Throw.TypeOf<AssertionException>());
	}
}
