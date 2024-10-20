﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class IsNotEmptyTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable enumerable = new ThrowWhenIteratingTwiceEnumerable();

			async Task Act()
				=> await Expect.That(enumerable).IsNotEmpty()
					.And.IsNotEmpty();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			async Task Act()
				=> await Expect.That(Factory.GetFibonacciNumbers()).IsNotEmpty();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldSucceed()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 2]);

			async Task Act()
				=> await Expect.That(enumerable).IsNotEmpty();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldFail()
		{
			IEnumerable<int> enumerable = ToEnumerable([]);

			async Task Act()
				=> await Expect.That(enumerable).IsNotEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that enumerable
				                  is not empty,
				                  but it was
				                  at Expect.That(enumerable).IsNotEmpty()
				                  """);
		}
	}
}
