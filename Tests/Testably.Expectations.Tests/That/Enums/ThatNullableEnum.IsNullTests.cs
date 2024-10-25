namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsNullTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData((MyColors)42)]
		public async Task WhenSubjectIsNotNull_ShouldFail(MyColors? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is null,
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNull()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNull();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
