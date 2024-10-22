using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class AtMostAreTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable enumerable = new();

			async Task Act()
				=> await Expect.That(enumerable).AtMost(3).Are(1)
					.And.AtMost(3).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			async Task Act()
				=> await Expect.That(Factory.GetFibonacciNumbers()).AtMost(1).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that Factory.GetFibonacciNumbers()
				                  has at most 1 item equal to 1,
				                  but at least 2 items were equal
				                  at Expect.That(Factory.GetFibonacciNumbers()).AtMost(1).Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsSufficientlyFewEqualItems_ShouldSucceed()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(enumerable).AtMost(3).Are(2);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsTooManyEqualItems_ShouldFail()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(enumerable).AtMost(3).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that enumerable
				                  has at most 3 items equal to 1,
				                  but at least 4 items were equal
				                  at Expect.That(enumerable).AtMost(3).Are(1)
				                  """);
		}
	}
}
