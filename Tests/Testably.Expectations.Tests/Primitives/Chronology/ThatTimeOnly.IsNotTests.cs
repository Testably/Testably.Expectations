#if NET6_0_OR_GREATER
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatTimeOnly
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task Fails_For_Same_Value()
		{
			TimeOnly value = CurrentTime();
			TimeOnly unexpected = value;

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
		public async Task Succeeds_For_Different_Value()
		{
			TimeOnly value = CurrentTime();
			TimeOnly unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
#endif
