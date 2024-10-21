using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenValuesAreTheSame_ShouldFail()
		{
			DateTime value = CurrentTime();
			DateTime unexpected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {unexpected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreDifferent_ShouldSucceed()
		{
			DateTime value = CurrentTime();
			DateTime unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
