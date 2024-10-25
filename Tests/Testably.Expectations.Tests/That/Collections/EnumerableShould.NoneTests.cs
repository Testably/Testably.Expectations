using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class EnumerableShould
{
	public sealed class NoneTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().None().Be(15)
						.And.None().Be(81);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().None().Be(5);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  have no items equal to 5,
				                  but at least one items were equal
				                  at Expect.That(subject).Should().None().Be(5)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsEqualValues_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().None().Be(1);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  have no items equal to 1,
				                  but at least one items were equal
				                  at Expect.That(subject).Should().None().Be(1)
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableOnlyContainsDifferentValues_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().None().Be(42);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
