namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsNotDefinedTests
	{
		[Fact]
		public async Task WhenValueIsNotDefined_ShouldSucceed()
		{
			var value = (MyColors)42;

			async Task Act()
				=> await Expect.That(value).IsNotDefined();

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValueIsDefined_ShouldFail(MyColors value)
		{
			async Task Act()
				=> await Expect.That(value).IsNotDefined();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not defined,
				                   but found {value}
				                   at Expect.That(value).IsNotDefined()
				                   """);
		}
	}
}
