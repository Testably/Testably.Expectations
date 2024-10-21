using System.Collections.Generic;
using System.Threading.Tasks;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class ContainsTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable enumerable = new ThrowWhenIteratingTwiceEnumerable();

			async Task Act()
				=> await Expect.That(enumerable).Contains(1)
					.And.Contains(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			async Task Act()
				=> await Expect.That(Factory.GetFibonacciNumbers()).Contains(5);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableContainsExpectedValue_ShouldSucceed(List<string> enumerable,
			string expected)
		{
			enumerable.Add(expected);

			async Task Act()
				=> await Expect.That(enumerable).Contains(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableDoesNotContainsExpectedValue_ShouldFail(string[] enumerable,
			string expected)
		{
			async Task Act()
				=> await Expect.That(enumerable).Contains(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that enumerable
				                   contains "{expected}",
				                   but found ["{string.Join("\", \"", enumerable)}"]
				                   at Expect.That(enumerable).Contains(expected)
				                   """);
		}
	}
}
