using AutoFixture.Xunit2;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Exceptions;
public class HasMessageTests
{
	[Theory]
	[AutoData]
	public async Task SucceedsForSameStrings(string actual)
	{
		var sut = new Exception(actual);
		async Task Act()
			=> await Expect.That(sut).HasMessage(actual);

		await Act();
	}

	[Theory]
	[AutoData]
	public async Task FailsWhenNotNull(string actual, string expected)
	{
		var sut = new Exception(actual);
		async Task Act()
			=> await Expect.That(sut).HasMessage(expected);

		var exception = await Assert.ThrowsAsync<XunitException>(Act);
		Assert.Equal($"""
			Expected that sut
			has Message equal to "{expected}",
			but found "{actual}" which differs at index 0:
			    ↓
			   "{actual}"
			   "{expected}"
			    ↑
			at Expect.That(sut).HasMessage(expected)
			""", exception.Message);
	}
}
