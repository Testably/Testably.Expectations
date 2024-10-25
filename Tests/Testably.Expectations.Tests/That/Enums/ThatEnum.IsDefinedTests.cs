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

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotDefined_ShouldFail()
		{
			MyColors subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).Should().IsDefined();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is defined,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsDefined()
				                   """);
		}
	}
}
