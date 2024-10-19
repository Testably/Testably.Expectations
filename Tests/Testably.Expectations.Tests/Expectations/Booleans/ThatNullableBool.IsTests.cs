using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(true, false)]
		[InlineData(true, null)]
		[InlineData(false, true)]
		[InlineData(false, null)]
		[InlineData(null, true)]
		[InlineData(null, false)]
		public async Task Fails_For_Different_Value(bool? value, bool? expected)
		{
			async Task Act()
				=> await That(value).Is(expected);

			await That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected?.ToString() ?? "<null>"},
				                   but found {value?.ToString() ?? "<null>"}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		[InlineData(null)]
		public async Task Succeeds_For_Same_Value(bool? value)
		{
			bool? expected = value;

			async Task Act()
				=> await That(value).Is(expected);

			await That(Act).DoesNotThrow();
		}
	}
}
