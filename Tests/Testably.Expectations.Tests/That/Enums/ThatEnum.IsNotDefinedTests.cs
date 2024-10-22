namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsNotDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsDefined_ShouldFail(MyColors subject)
		{
			async Task Act()
				=> await Expect.That(subject).IsNotDefined();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not defined,
				                   but found {subject}
				                   at Expect.That(subject).IsNotDefined()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNotDefined_ShouldSucceed()
		{
			MyColors subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).IsNotDefined();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
