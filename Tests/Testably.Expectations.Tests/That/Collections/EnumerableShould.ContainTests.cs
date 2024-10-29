using System.Collections.Generic;
using Testably.Expectations.Tests.TestHelpers;
// ReSharper disable PossibleMultipleEnumeration

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class EnumerableShould
{
	public sealed class ContainTests
	{
		[Fact]
		public async Task DoesNotEnumerateTwice()
		{
			ThrowWhenIteratingTwiceEnumerable subject = new();

			async Task Act()
				=> await Expect.That(subject).Should().Contain(1)
					.And.Contain(1);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task DoesNotMaterializeEnumerable()
		{
			IEnumerable<int> subject = Factory.GetFibonacciNumbers();

			async Task Act()
				=> await Expect.That(subject).Should().Contain(5);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableContainsExpectedValue_ShouldSucceed(List<string> subject,
			string expected)
		{
			subject.Add(expected);

			async Task Act()
				=> await Expect.That(subject).Should().Contain(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenEnumerableDoesNotContainsExpectedValue_ShouldFail(string[] subject,
			string expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Contain(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              contain "{expected}",
				              but found ["{string.Join("\", \"", subject)}"]
				              at Expect.That(subject).Should().Contain(expected)
				              """);
		}
	}
}
