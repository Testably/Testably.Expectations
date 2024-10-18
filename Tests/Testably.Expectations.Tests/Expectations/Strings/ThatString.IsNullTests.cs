using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Strings;

public sealed partial class ThatString
{
	public class IsNullTests
	{
		[Theory]
		[AutoData]
		public async Task FailsWhenNotNull(string? actual)
		{
			async Task Act()
				=> await Expect.That(actual).IsNull();

			XunitException exception = await Assert.ThrowsAsync<XunitException>(Act);
			Assert.Equal($"""
			              Expected that actual
			              is null,
			              but found "{actual}"
			              at Expect.That(actual).IsNull()
			              """, exception.Message);
		}

		[Fact]
		public async Task SucceedsWhenNull()
		{
			string? actual = null;

			async Task Act()
				=> await Expect.That(actual).IsNull();

			await Act();
		}
	}
}
