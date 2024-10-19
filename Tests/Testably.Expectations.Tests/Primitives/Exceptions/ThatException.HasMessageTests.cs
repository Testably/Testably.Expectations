using AutoFixture.Xunit2;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Exceptions;

public sealed partial class ThatException
{
	public sealed class HasMessageTests
	{
		[Theory]
		[AutoData]
		public async Task FailsForDifferentStrings(string actual, string expected)
		{
			Exception sut = new Exception(actual);

			async Task Act()
				=> await Expect.That(sut).HasMessage(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that sut
				                   has Message equal to "{expected}",
				                   but found "{actual}" which differs at index 0:
				                       ↓
				                      "{actual}"
				                      "{expected}"
				                       ↑
				                   at Expect.That(sut).HasMessage(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception sut = new Exception(actual);

			async Task Act()
				=> await Expect.That(sut).HasMessage(actual);

			await Expect.That(Act).DoesNotThrow();
		}
	}

}
