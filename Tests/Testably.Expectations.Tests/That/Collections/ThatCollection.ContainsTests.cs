using System.Collections.Generic;

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class ContainsTests
	{
		[Theory]
		[AutoData]
		public async Task Fails(string[] subject, string expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Contains(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   contains "{expected}",
				                   but found ["{string.Join("\", \"", subject)}"]
				                   at Expect.That(subject).Should().Contains(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task Succeeds(List<string> subject, string expected)
		{
			subject.Add(expected);

			async Task Act()
				=> await Expect.That(subject).Should().Contains(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
