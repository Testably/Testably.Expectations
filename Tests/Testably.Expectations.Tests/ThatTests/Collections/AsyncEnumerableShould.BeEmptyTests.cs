#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Threading;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.ThatTests.Collections;

public sealed partial class AsyncEnumerableShould
{
	public sealed class BeEmptyTests
	{
		[Fact]
		public async Task CancelledEnumerable_ShouldFail()
		{
			using CancellationTokenSource cts = new();
			cts.Cancel();
			CancellationToken token = cts.Token;
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([]);

			async Task Act()
				=> await That(subject).Should().BeEmpty().WithCancellation(token);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be empty,
				             but could not evaluate it, because it was already cancelled
				             at Expect.That(subject).Should().BeEmpty().WithCancellation(token)
				             """);
		}

		[Fact]
		public async Task ConsidersCancellationToken()
		{
			using CancellationTokenSource cts = new();
			CancellationToken token = cts.Token;
			IAsyncEnumerable<int> subject =
				GetCancellingAsyncEnumerable(5, cts, CancellationToken.None);

			async Task Act()
				=> await That(subject).Should().BeEmpty().WithCancellation(token);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be empty,
				             but found [0, 1, 2, 3, 4]
				             at Expect.That(subject).Should().BeEmpty().WithCancellation(token)
				             """);
		}

		[Fact]
		public async Task ShouldDisplayUpToTenItems()
		{
			using CancellationTokenSource cts = new();
			IAsyncEnumerable<int> subject =
				GetCancellingAsyncEnumerable(16, cts, CancellationToken.None);

			async Task Act()
				=> await That(subject).Should().BeEmpty();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be empty,
				             but found [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, …]
				             at Expect.That(subject).Should().BeEmpty()
				             """);
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldFail()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 2]);

			async Task Act()
				=> await That(subject).Should().BeEmpty();

			await That(Act).Should().Throw<XunitException>()
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
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([]);

			async Task Act()
				=> await That(subject).Should().BeEmpty();

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeEmptyTests
	{
		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldSucceed()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([1, 1, 2]);

			async Task Act()
				=> await That(subject).Should().NotBeEmpty();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldFail()
		{
			IAsyncEnumerable<int> subject = ToAsyncEnumerable([]);

			async Task Act()
				=> await That(subject).Should().NotBeEmpty();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be empty,
				             but it was
				             at Expect.That(subject).Should().NotBeEmpty()
				             """);
		}
	}
}
#endif
