namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsNotDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValueIsDefined_ShouldFail(MyColors? subject)
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
		public async Task WhenValueIsNotDefined_ShouldSucceed()
		{
			MyColors? subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).IsNotDefined();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNotDefined();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not defined,
				                  but found <null>
				                  at Expect.That(subject).IsNotDefined()
				                  """);
		}
	}
}
