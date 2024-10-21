using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			async Task Act()
				=> await Expect.That(Factory.GetFibonacciNumbers()).IsEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that Factory.GetFibonacciNumbers()
				                  is empty,
				                  but found [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, …]
				                  at Expect.That(Factory.GetFibonacciNumbers()).IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableContainsValues_ShouldFail()
		{
			IEnumerable<int> enumerable = ToEnumerable([1, 1, 2]);

			async Task Act()
				=> await Expect.That(enumerable).IsEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that enumerable
				                  is empty,
				                  but found [1, 1, 2]
				                  at Expect.That(enumerable).IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenEnumerableIsEmpty_ShouldSucceed()
		{
			IEnumerable<int> enumerable = ToEnumerable([]);

			async Task Act()
				=> await Expect.That(enumerable).IsEmpty();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
