﻿using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsOnOrAfterTests
	{
		[Fact]
		public async Task WhenValueIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = EarlierTime();

			async Task Act()
				=> await Expect.That(value).IsOnOrAfter(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is on or after {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsOnOrAfter(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValueIsSame_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = expected;

			async Task Act()
				=> await Expect.That(value).IsOnOrAfter(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValuesIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = LaterTime();

			async Task Act()
				=> await Expect.That(value).IsOnOrAfter(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
