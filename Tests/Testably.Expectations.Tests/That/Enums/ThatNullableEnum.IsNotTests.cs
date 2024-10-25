namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsNotTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		[InlineData(null)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors? subject)
		{
			MyColors? unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is not {unexpected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Blue, null)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		[InlineData(MyColors.Green, null)]
		[InlineData(null, MyColors.Blue)]
		[InlineData(null, MyColors.Green)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(MyColors? subject, MyColors? unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(null);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  is not <null>,
				                  but found <null>
				                  at Expect.That(subject).Should().IsNot(null)
				                  """);
		}
	}
}
