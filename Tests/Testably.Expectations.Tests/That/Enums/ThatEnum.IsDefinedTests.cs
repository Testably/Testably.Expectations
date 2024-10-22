namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsDefined_ShouldSucceed(MyColors subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsDefined();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotDefined_ShouldFail()
		{
			MyColors subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).Should().IsDefined();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is defined,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsDefined()
				                   """);
		}
	}
}
