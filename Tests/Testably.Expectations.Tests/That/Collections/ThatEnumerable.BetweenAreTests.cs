using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class BetweenAreTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().Between(0).And(2).Are(1)
					.And.Between(0).And(1).Are(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().Between(0).And(1).Are(1);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has between 0 and 1 items equal to 1,
				                  but at least 2 items were equal
				                  at Expect.That(subject).Between(0).And(1).Should().Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsSufficientlyEqualItems_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().Between(3).And(4).Are(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsTooFewEqualItems_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().Between(3).And(4).Are(2);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has between 3 and 4 items equal to 2,
				                  but only 2 items were equal
				                  at Expect.That(subject).Between(3).And(4).Should().Are(2)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsTooManyEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Should().Between(1).And(3).Are(1);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has between 1 and 3 items equal to 1,
				                  but 4 items were equal
				                  at Expect.That(subject).Between(1).And(3).Should().Are(1)
				                  """);
		}
	}
}
