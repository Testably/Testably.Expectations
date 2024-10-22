namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Blue, null)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		[InlineData(MyColors.Green, null)]
		[InlineData(null, MyColors.Blue)]
		[InlineData(null, MyColors.Green)]
		public async Task WhenSubjectIsDifferent_ShouldFail(MyColors? subject, MyColors? expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(MyColors? subject)
		{
			MyColors? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().Is(MyColors.Red);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is Red,
				                  but found <null>
				                  at Expect.That(subject).Should().Is(MyColors.Red)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreNull_ShouldSucceed()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().Is(null);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
