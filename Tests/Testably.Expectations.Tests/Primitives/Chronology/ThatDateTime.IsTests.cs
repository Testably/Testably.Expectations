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
		public async Task Fails_For_Different_Value()
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
		public async Task Succeeds_For_Same_Value()
		{
			DateTime value = CurrentTime();
			DateTime expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
