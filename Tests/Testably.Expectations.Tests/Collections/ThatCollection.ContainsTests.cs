using System.Collections.Generic;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class ContainsTests
	{
		[Theory]
		[AutoData]
		public async Task Fails(string[] collection, string expected)
		{
			async Task Act()
				=> await Expect.That(collection).Contains(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that collection
				                   contains "{expected}",
				                   but found ["{string.Join("\", \"", collection)}"]
				                   at Expect.That(collection).Contains(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task Succeeds(List<string> collection, string expected)
		{
			collection.Add(expected);

			async Task Act()
				=> await Expect.That(collection).Contains(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
