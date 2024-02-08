﻿using NUnit.Framework;
using System;

namespace Testably.Expectations.Tests;

public sealed class NUnit4TestFrameworkTests
{
	[Test]
	public void WhenUsingNUnit4AsTestFramework_ShouldThrowAssertionException()
	{
		Action act = () => Expect.That(true, Should.Be.False());

		Expect.That(act, Should.Throw.TypeOf<AssertionException>());
	}
}
