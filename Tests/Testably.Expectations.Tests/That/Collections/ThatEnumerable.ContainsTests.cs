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
				=> await Expect.That(subject).Contains(1)
					.And.Contains(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			var subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Contains(5);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableContainsExpectedValue_ShouldSucceed(List<string> subject,
			string expected)
		{
			subject.Add(expected);

			async Task Act()
				=> await Expect.That(subject).Contains(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableDoesNotContainsExpectedValue_ShouldFail(string[] subject,
			string expected)
		{
			async Task Act()
				=> await Expect.That(subject).Contains(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   contains "{expected}",
				                   but found ["{string.Join("\", \"", subject)}"]
				                   at Expect.That(subject).Contains(expected)
				                   """);
		}
	}
}
