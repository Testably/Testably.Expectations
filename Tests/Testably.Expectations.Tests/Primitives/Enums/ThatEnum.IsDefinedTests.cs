namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValueIsDefined_ShouldSucceed(MyColors value)
		{
			async Task Act()
				=> await Expect.That(value).IsDefined();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValueIsNotDefined_ShouldFail()
		{
			MyColors value = (MyColors)42;

			async Task Act()
				=> await Expect.That(value).IsDefined();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is defined,
				                   but found {value}
				                   at Expect.That(value).IsDefined()
				                   """);
		}
	}
}
