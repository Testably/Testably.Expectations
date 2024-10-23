using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatEnumerable
{
	public sealed class ContainsTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().Contains(1)
					.And.Contains(1);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().Contains(5);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableContainsExpectedValue_ShouldSucceed(List<string> subject,
			string expected)
		{
			subject.Add(expected);

			async Task Act()
				=> await Expect.That(subject).Should().Contains(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableDoesNotContainsExpectedValue_ShouldFail(string[] subject,
			string expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Contains(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   contains "{expected}",
				                   but found ["{string.Join("\", \"", subject)}"]
				                   at Expect.That(subject).Should().Contains(expected)
				                   """);
		}
	}
}
