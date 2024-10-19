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
				=> await That(actual).IsNull();

			await That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that actual
				                   is null,
				                   but found "{actual}"
				                   at Expect.That(actual).IsNull()
				                   """);
		}

		[Fact]
		public async Task SucceedsWhenNull()
		{
			string? actual = null;

			async Task Act()
				=> await That(actual).IsNull();

			await Act();
		}
	}
}
