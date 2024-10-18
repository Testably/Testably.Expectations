using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Strings;

public sealed partial class ThatString
{
	public class IsTests
	{
		[Theory]
		[AutoData]
		public async Task FailsWhenNotNull(string actual, string expected)
		{
			async Task Act()
				=> await Expect.That(actual).Is(expected);

			XunitException exception = await Assert.ThrowsAsync<XunitException>(Act);
			Assert.Equal($"""
			              Expected that actual
			              is equal to "{expected}",
			              but found "{actual}"
			              at Expect.That(actual).Is(expected)
			              """, exception.Message);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			async Task Act()
				=> await Expect.That(actual).Is(actual);

			await Act();
		}
	}
}
