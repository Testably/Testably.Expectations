﻿using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.ThatTests.Collections;

public sealed partial class EnumerableShould
{
	public sealed class AllTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await That(subject).Should().All().Satisfy(_ => true)
					.And.All().Satisfy(_ => true);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			IEnumerable<int> subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await That(subject).Should().All().Be(1);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have all items equal to 1,
				             but not all items were equal
				             at Expect.That(subject).Should().All().Be(1)
				             """);
		}

		[Fact]
		public async Task WhenEnumerableContainsDifferentValues_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 2, 2, 3]);

			async Task Act()
				=> await That(subject).Should().All().Be(1);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have all items equal to 1,
				             but not all items were equal
				             at Expect.That(subject).Should().All().Be(1)
				             """);
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([]);

			async Task Act()
				=> await That(subject).Should().All().Be(0);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenEnumerableOnlyContainsEqualValues_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 1, 1, 1, 1, 1]);

			async Task Act()
				=> await That(subject).Should().All().Be(1);

			await That(Act).Should().NotThrow();
		}
	}
}
