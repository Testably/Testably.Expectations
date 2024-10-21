namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotOnOrBeforeTests
	{
		[Fact]
		public async Task WhenValueIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = EarlierTime();

			async Task Act()
				=> await Expect.That(value).IsNotOnOrBefore(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not on or before {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsNotOnOrBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValueIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = expected;

			async Task Act()
				=> await Expect.That(value).IsNotOnOrBefore(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not on or before {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsNotOnOrBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = LaterTime();

			async Task Act()
				=> await Expect.That(value).IsNotOnOrBefore(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime value = EarlierTime(3);

			async Task Act()
				=> await Expect.That(value).IsNotOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not on or before {expected:O} ± 0:03,
				                   but found {value:O}
				                   at Expect.That(value).IsNotOnOrBefore(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime value = EarlierTime(2);

			async Task Act()
				=> await Expect.That(value).IsNotOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
