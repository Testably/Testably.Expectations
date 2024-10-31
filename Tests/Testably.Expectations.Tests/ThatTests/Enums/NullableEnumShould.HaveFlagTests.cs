namespace Testably.Expectations.Tests.ThatTests.Enums;

public sealed partial class NullableEnumShould
{
	public sealed class HaveFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue | MyColors.Red, MyColors.Green)]
		[InlineData(MyColors.Green | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldFail(MyColors? subject,
			MyColors expected)
		{
			async Task Act()
				=> await That(subject).Should().HaveFlag(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              have flag {expected},
				              but found {subject}
				              at Expect.That(subject).Should().HaveFlag(expected)
				              """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectHasFlag_ShouldSucceed(MyColors expected)
		{
			MyColors? subject = MyColors.Yellow | MyColors.Red | expected;

			async Task Act()
				=> await That(subject).Should().HaveFlag(expected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(MyColors expected)
		{
			MyColors? subject = expected;

			async Task Act()
				=> await That(subject).Should().HaveFlag(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotHaveFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldSucceed(MyColors unexpected)
		{
			MyColors? subject = MyColors.Yellow | (MyColors.Red & ~unexpected);

			async Task Act()
				=> await That(subject).Should().NotHaveFlag(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue | MyColors.Green, MyColors.Green)]
		[InlineData(MyColors.Blue | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectHasFlag_ShouldFail(MyColors? subject, MyColors unexpected)
		{
			async Task Act()
				=> await That(subject).Should().NotHaveFlag(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not have flag {unexpected},
				              but found {subject}
				              at Expect.That(subject).Should().NotHaveFlag(unexpected)
				              """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors unexpected)
		{
			MyColors? subject = unexpected;

			async Task Act()
				=> await That(subject).Should().NotHaveFlag(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not have flag {unexpected},
				              but found {subject}
				              at Expect.That(subject).Should().NotHaveFlag(unexpected)
				              """);
		}
	}
}
