﻿using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsOnOrBeforeTests
	{
		[Fact]
		public async Task WhenValueIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = LaterTime();

			async Task Act()
				=> await Expect.That(value).IsOnOrBefore(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is on or before {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsOnOrBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValueIsSame_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = expected;

			async Task Act()
				=> await Expect.That(value).IsOnOrBefore(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValuesIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = EarlierTime();

			async Task Act()
				=> await Expect.That(value).IsOnOrBefore(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = LaterTime(4);

			async Task Act()
				=> await Expect.That(value).IsOnOrBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is on or before {expected:O} ± 0:03,
				                   but found {value:O}
				                   at Expect.That(value).IsOnOrBefore(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = LaterTime(3);

			async Task Act()
				=> await Expect.That(value).IsOnOrBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
