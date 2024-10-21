using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatTimeSpan
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task Fails_For_Same_Value()
		{
			TimeSpan value = CurrentTime();
			TimeSpan unexpected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {unexpected:g},
				                   but found {value:g}
				                   at Expect.That(value).IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task Succeeds_For_Different_Value()
		{
			TimeSpan value = CurrentTime();
			TimeSpan unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
