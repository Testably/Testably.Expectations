#if NET6_0_OR_GREATER
using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class AsyncEnumerableShould
{
	public sealed class AtLeastTests
	{
		[Fact]
		public async Task WhenEnumerableContainsEnoughEqualItems_ShouldSucceed()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(3).Be(1);

			await Expect.That(Act).Should().NotThrow();
		}
		[Fact]
		public async Task WhenEnumerableContainsTooFewEqualItems_ShouldFail()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(5).Be(1);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have at least 5 items equal to 1,
				             but only 4 of 7 items were equal
				             at Expect.That(subject).Should().AtLeast(5).Be(1)
				             """);
		}
		[Fact]
		public async Task WhenEnumerableContainsTooFewEquivalentItems_ShouldFail()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(5).BeEquivalentTo(1);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have at least 5 items equivalent to 1,
				             but only 4 of 7 items were equivalent
				             at Expect.That(subject).Should().AtLeast(5).BeEquivalentTo(1)
				             """);
		}
	}
}
#endif
