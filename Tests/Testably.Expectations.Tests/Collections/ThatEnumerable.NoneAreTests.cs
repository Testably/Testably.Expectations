using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class NoneAreTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable enumerable = new ThrowWhenIteratingTwiceEnumerable();

			async Task Act()
				=> await Expect.That(enumerable).None().Are(15)
					.And.None().Are(81);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			async Task Act()
				=> await Expect.That(Factory.GetFibonacciNumbers()).None().Are(5);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that Factory.GetFibonacciNumbers()
				                  has no items equal to 5,
				                  but at least one items were equal
				                  at Expect.That(Factory.GetFibonacciNumbers()).None().Are(5)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsEqualValues_ShouldFail()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(enumerable).None().Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that enumerable
				                  has no items equal to 1,
				                  but at least one items were equal
				                  at Expect.That(enumerable).None().Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableOnlyContainsDifferentValues_ShouldSucceed()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(enumerable).None().Are(42);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
