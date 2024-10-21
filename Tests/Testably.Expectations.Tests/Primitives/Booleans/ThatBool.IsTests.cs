namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task Fails_For_Different_Value(bool value)
		{
			bool expected = !value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected},
				                   but found {value}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task Succeeds_For_Same_Value(bool value)
		{
			bool expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
