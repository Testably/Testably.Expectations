using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsNotTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task Fails_For_Same_Value(bool value)
		{
			bool unexpected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {unexpected},
				                   but found {value}
				                   at Expect.That(value).IsNot(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task Succeeds_For_Different_Value(bool value)
		{
			bool unexpected = !value;

			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
