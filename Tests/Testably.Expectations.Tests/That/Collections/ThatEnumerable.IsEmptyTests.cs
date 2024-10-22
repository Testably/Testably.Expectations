using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is empty,
				                  but found [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, …]
				                  at Expect.That(subject).Should().IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 2]);

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is empty,
				                  but found [1, 1, 2]
				                  at Expect.That(subject).Should().IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([]);

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
