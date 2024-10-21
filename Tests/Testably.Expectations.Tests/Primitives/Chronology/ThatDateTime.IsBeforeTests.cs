using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsBeforeTests
	{
		[Fact]
		public async Task WhenValueIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = LaterTime();

			async Task Act()
				=> await Expect.That(value).IsBefore(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is before {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValueIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = expected;

			async Task Act()
				=> await Expect.That(value).IsBefore(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is before {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = EarlierTime();

			async Task Act()
				=> await Expect.That(value).IsBefore(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
