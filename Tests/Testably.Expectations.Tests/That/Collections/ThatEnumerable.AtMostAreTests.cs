using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class AtMostAreTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().AtMost(3).Are(1)
					.And.AtMost(3).Are(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().AtMost(1).Are(1);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has at most 1 item equal to 1,
				                  but at least 2 items were equal
				                  at Expect.That(subject).AtMost(1).Should().Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsSufficientlyFewEqualItems_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtMost(3).Are(2);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsTooManyEqualItems_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtMost(3).Are(1);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has at most 3 items equal to 1,
				                  but at least 4 items were equal
				                  at Expect.That(subject).AtMost(3).Should().Are(1)
				                  """);
		}
	}
}
