﻿using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class IsNotEmptyTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty()
					.And.IsNotEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 2]);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([]);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not empty,
				                  but it was
				                  at Expect.That(subject).Should().IsNotEmpty()
				                  """);
		}
	}
}