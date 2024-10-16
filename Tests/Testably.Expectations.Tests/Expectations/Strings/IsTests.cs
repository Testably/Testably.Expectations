using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Strings;
public class IsTests
{
	[Theory]
	[AutoData]
	public async Task SucceedsForSameStrings(string actual)
	{
		async Task Act()
			=> await Expect.That(actual).Is(actual);

		await Act();
	}

	[Theory]
	[AutoData]
	public async Task FailsWhenNotNull(string actual, string expected)
	{
		async Task Act()
			=> await Expect.That(actual).Is(expected);

		var exception = await Assert.ThrowsAsync<XunitException>(Act);
		Assert.Equal($"""
			Expected that actual
			is equal to "{expected}",
			but found "{actual}"
			at Expect.That(actual).Is(expected)
			""", exception.Message);
	}
}
