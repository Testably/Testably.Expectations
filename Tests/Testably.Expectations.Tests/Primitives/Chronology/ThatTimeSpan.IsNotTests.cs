using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Formatting;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatTimeSpan
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenValuesAreTheSame_ShouldFail()
		{
			TimeSpan value = CurrentTime();
			TimeSpan unexpected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {Formatter.Format(unexpected)},
				                   but found {Formatter.Format(value)}
				                   at Expect.That(value).IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreDifferent_ShouldSucceed()
		{
			TimeSpan value = CurrentTime();
			TimeSpan unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
