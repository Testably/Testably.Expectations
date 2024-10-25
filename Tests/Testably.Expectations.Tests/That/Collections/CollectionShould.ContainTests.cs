using System.Collections.Generic;

namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class CollectionShould
{
	public sealed class ContainTests
	{
		[Theory]
		[AutoData]
		public async Task Fails(string[] subject, string expected)
		{
			async Task Act()
				=> await Expectations.ThatCollectionShould.Contain(Expect.That(subject).Should(), expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   contain "{expected}",
				                   but found ["{string.Join("\", \"", subject)}"]
				                   at Expect.That(subject).Should().Contain(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task Succeeds(List<string> subject, string expected)
		{
			subject.Add(expected);

			async Task Act()
				=> await Expectations.ThatCollectionShould.Contain(Expect.That(subject).Should(), expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
