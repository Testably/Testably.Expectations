namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValueIsDefined_ShouldSucceed(MyColors subject)
		{
			async Task Act()
				=> await Expect.That(subject).IsDefined();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValueIsNotDefined_ShouldFail()
		{
			MyColors subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).IsDefined();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is defined,
				                   but found {subject}
				                   at Expect.That(subject).IsDefined()
				                   """);
		}
	}
}
