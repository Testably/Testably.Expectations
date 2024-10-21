using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class AtLeastAreTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable enumerable = new ThrowWhenIteratingTwiceEnumerable();

			async Task Act()
				=> await Expect.That(enumerable).AtLeast(0).Are(1)
					.And.AtLeast(0).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			async Task Act()
				=> await Expect.That(Factory.GetFibonacciNumbers()).AtLeast(2).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsEnoughEqualItems_ShouldSucceed()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(enumerable).AtLeast(3).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsTooFewEqualItems_ShouldFail()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(enumerable).AtLeast(5).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that enumerable
				                  has at least 5 items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(enumerable).AtLeast(5).Are(1)
				                  """);
		}
	}
}
