using System.Collections.Generic;

namespace Testably.Expectations.Tests.ThatTests.Collections;

public sealed partial class CollectionShould
{
	public sealed class ContainTests
	{
		[Theory]
		[AutoData]
		public async Task Fails(string[] subject, string expected)
		{
			async Task Act()
				=> await That(subject).Should().Contain(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              contain "{expected}",
				              but found ["{string.Join("\", \"", subject)}"].
				              """);
		}

		[Theory]
		[AutoData]
		public async Task Succeeds(List<string> subject, string expected)
		{
			subject.Add(expected);

			async Task Act()
				=> await That(subject).Should().Contain(expected);

			await That(Act).Should().NotThrow();
		}
	}
}
