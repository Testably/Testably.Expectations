using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldFail()
		{
			int[] collection = [1, 1, 2];

			async Task Act()
				=> await Expect.That(collection).IsEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  is empty,
				                  but found [1, 1, 2]
				                  at Expect.That(collection).IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldSucceed()
		{
			int[] collection = [];

			async Task Act()
				=> await Expect.That(collection).IsEmpty();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
