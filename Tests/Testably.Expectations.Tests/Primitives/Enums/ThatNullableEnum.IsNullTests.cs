namespace Testably.Expectations.Tests.Primitives.Enums;

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
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is null,
				                   but found {subject}
				                   at Expect.That(subject).IsNull()
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).IsNull();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
