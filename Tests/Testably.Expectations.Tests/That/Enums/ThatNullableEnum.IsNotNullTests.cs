namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsNotNullTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData((MyColors)42)]
		public async Task WhenSubjectIsNotNull_ShouldSucceed(MyColors? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotNull();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is not null,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNotNull()
				                  """);
		}
	}
}
