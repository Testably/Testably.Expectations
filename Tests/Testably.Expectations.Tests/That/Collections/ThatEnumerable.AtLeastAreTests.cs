using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class AtLeastAreTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(0).Are(1)
					.And.AtLeast(0).Are(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(2).Are(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsEnoughEqualItems_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(3).Are(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsTooFewEqualItems_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(5).Are(1);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has at least 5 items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(subject).AtLeast(5).Should().Are(1)
				                  """);
		}
	}
}
