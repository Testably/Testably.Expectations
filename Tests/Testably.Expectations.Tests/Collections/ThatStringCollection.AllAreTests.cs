using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatStringCollection
{
	public sealed class AllAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsOtherValues_ShouldFail()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).All().Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  has all items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(collection).All().Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionOnlyContainsEqualValues_ShouldSucceed()
		{
			int[] collection = [1, 1, 1, 1];

			async Task Act()
				=> await Expect.That(collection).All().Are(1);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
