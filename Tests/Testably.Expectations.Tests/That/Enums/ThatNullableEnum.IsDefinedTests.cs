namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsDefined_ShouldSucceed(MyColors? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsDefined();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotDefined_ShouldFail()
		{
			MyColors? subject = (MyColors)42;

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

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsDefined();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is defined,
				                  but found <null>
				                  at Expect.That(subject).Should().IsDefined()
				                  """);
		}
	}
}
