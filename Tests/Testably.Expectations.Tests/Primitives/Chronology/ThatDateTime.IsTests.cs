using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenValuesAreDifferent_ShouldFail()
		{
			DateTime value = CurrentTime();
			DateTime expected = LaterTime();

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreTheSame_ShouldSucceed()
		{
			DateTime value = CurrentTime();
			DateTime expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime value = CurrentTime();
			DateTime expected = LaterTime(4);

			async Task Act()
				=> await Expect.That(value).Is(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected:O} ± 0:03,
				                   but found {value:O}
				                   at Expect.That(value).Is(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime value = CurrentTime();
			DateTime expected = LaterTime(3);

			async Task Act()
				=> await Expect.That(value).Is(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
