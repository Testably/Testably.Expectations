using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatStringCollection
{
	public sealed class AtMostAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsTooManyEqualItems_ShouldFail()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).AtMost(3).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  has at most 3 items equal to 1,
				                  but 4 of 7 items were equal
				                  at Expect.That(collection).AtMost(3).Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionContainsSufficientlyFewEqualItems_ShouldSucceed()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).AtMost(3).Are(2);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
