namespace Testably.Expectations.Tests.ThatTests.Enums;

public sealed partial class NullableEnumShould
{
	public sealed class HaveValueTests
	{
		[Theory]
		[InlineData(MyNumbers.One, 2L)]
		[InlineData(MyNumbers.Two, -7)]
		[InlineData(MyNumbers.Three, 0)]
		public async Task WhenSubjectDoesNotHaveExpectedValue_ShouldFail(MyNumbers? subject,
			long expected)
		{
			async Task Act()
				=> await That(subject).Should().HaveValue(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              have value {expected},
				              but found {subject}
				              at Expect.That(subject).Should().HaveValue(expected)
				              """);
		}

		[Theory]
		[InlineData(MyNumbers.One, 1)]
		[InlineData(MyNumbers.Two, 2)]
		[InlineData(MyNumbers.Three, 3)]
		public async Task WhenSubjectHasExpectedValue_ShouldSucceed(MyNumbers? subject,
			long expected)
		{
			async Task Act()
				=> await That(subject).Should().HaveValue(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotHaveValueTests
	{
		[Theory]
		[InlineData(MyNumbers.One, 2L)]
		[InlineData(MyNumbers.Two, -7)]
		[InlineData(MyNumbers.Three, 0)]
		public async Task WhenSubjectDoesNotHaveUnexpectedValue_ShouldSucceed(MyNumbers? subject,
			long unexpected)
		{
			async Task Act()
				=> await That(subject).Should().NotHaveValue(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyNumbers.One, 1)]
		[InlineData(MyNumbers.Two, 2)]
		[InlineData(MyNumbers.Three, 3)]
		public async Task WhenSubjectHasUnexpectedValue_ShouldFail(MyNumbers? subject,
			long unexpected)
		{
			async Task Act()
				=> await That(subject).Should().NotHaveValue(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not have value {unexpected},
				              but found {subject}
				              at Expect.That(subject).Should().NotHaveValue(unexpected)
				              """);
		}
	}
}
