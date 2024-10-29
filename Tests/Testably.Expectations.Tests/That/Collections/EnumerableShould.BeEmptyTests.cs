using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class EnumerableShould
{
	public sealed class BeEmptyTests
	{
		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			IEnumerable<int> subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().BeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be empty,
				             but found [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, …]
				             at Expect.That(subject).Should().BeEmpty()
				             """);
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 2]);

			async Task Act()
				=> await Expect.That(subject).Should().BeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be empty,
				             but found [1, 1, 2]
				             at Expect.That(subject).Should().BeEmpty()
				             """);
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([]);

			async Task Act()
				=> await Expect.That(subject).Should().BeEmpty();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeEmptyTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty()
					.And.NotBeEmpty();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			IEnumerable<int> subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldSucceed()
		{
			IEnumerable<int> subject = ToEnumerable([1, 1, 2]);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldFail()
		{
			IEnumerable<int> subject = ToEnumerable([]);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be empty,
				             but it was
				             at Expect.That(subject).Should().NotBeEmpty()
				             """);
		}
	}
}
