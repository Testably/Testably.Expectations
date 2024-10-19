using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Numbers;

public sealed partial class ThatNumber
{
	public sealed class IsNotTests
	{
		[Theory]
		[AutoData]
		public async Task Fails_For_Same_Value(int value)
		{
			int expected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {expected},
				                   but found {value}
				                   at Expect.That(value).IsNot(expected)
				                   """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task Succeeds_For_Different_Value(int value, int expected)
		{
			async Task Act()
				=> await Expect.That(value).IsNot(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
