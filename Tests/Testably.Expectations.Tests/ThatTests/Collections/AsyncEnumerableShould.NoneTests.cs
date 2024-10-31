#if NET6_0_OR_GREATER
using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.ThatTests.Collections;

public sealed partial class AsyncEnumerableShould
{
	public sealed class NoneTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await That(subject).Should().None().Be(15)
					.And.None().Be(81);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			IEnumerable<int> subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await That(subject).Should().None().Be(5);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have no items equal to 5,
				             but at least one items were equal
				             at Expect.That(subject).Should().None().Be(5)
				             """);
		}

		[Fact]
		public async Task WhenEnumerableContainsEqualValues_ShouldFail()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await That(subject).Should().None().Be(1);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have no items equal to 1,
				             but at least one items were equal
				             at Expect.That(subject).Should().None().Be(1)
				             """);
		}

		[Fact]
		public async Task WhenEnumerableOnlyContainsDifferentValues_ShouldSucceed()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await That(subject).Should().None().Be(42);

			await That(Act).Should().NotThrow();
		}
	}
}
#endif
