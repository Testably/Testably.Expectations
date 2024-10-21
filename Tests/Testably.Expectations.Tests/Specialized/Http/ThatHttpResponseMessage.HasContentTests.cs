using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class HasContentTests
	{
		[Fact]
		public async Task WhenContentDiffersFromExpected_ShouldFail()
		{
			string expected = "other content";
			HttpResponseMessage sut = Create("some content");

			async Task Act()
				=> await Expect.That(sut).HasContent(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has a string content equal to "other content",
				                  but found "some content" which differs at index 0:
				                     ↓ (actual)
				                    "some content"
				                    "other content"
				                     ↑ (expected)
				                  at Expect.That(sut).HasContent(expected)
				                  """);
		}

		[Fact]
		public async Task WhenContentEqualsExpected_ShouldSucceed()
		{
			string expected = "some content";
			HttpResponseMessage sut = Create(expected);

			async Task Act()
				=> await Expect.That(sut).HasContent(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
