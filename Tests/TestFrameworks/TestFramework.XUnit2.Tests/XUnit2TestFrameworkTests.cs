﻿using System.Threading.Tasks;
using Testably.Expectations;
using Xunit;
using Xunit.Sdk;

namespace TestFramework.XUnit2.Tests;

public sealed class XUnit2TestFrameworkTests
{
	[Fact]
	public async Task OnFail_WhenUsingXunit2AsTestFramework_ShouldThrowXunitException()
	{
		void Act()
			=> Fail.Test("my message");

		await Expect.That(Act).Throws<XunitException>();
	}

	[Fact]
	public async Task OnSkip_WhenUsingXunit2AsTestFramework_ShouldThrowSkipException()
	{
		void Act()
			=> Skip.Test("my message");

		await Expect.That(Act).Throws<Testably.Expectations.SkipException>()
			.Which.HasMessage("SKIPPED: my message (xunit v2 does not support skipping test)");
	}
}
