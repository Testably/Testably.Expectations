namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class DoesNotHaveValueTests
	{
		[Theory]
		[InlineData(MyNumbers.One, 2L)]
		[InlineData(MyNumbers.Two, -7)]
		[InlineData(MyNumbers.Three, 0)]
		public async Task WhenSubjectDoesNotHaveUnexpectedValue_ShouldSucceed(MyNumbers? subject,
			long unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveValue(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[InlineData(MyNumbers.One, 1)]
		[InlineData(MyNumbers.Two, 2)]
		[InlineData(MyNumbers.Three, 3)]
		public async Task WhenSubjectHasUnexpectedValue_ShouldFail(MyNumbers? subject, long unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveValue(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   does not have value {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().DoesNotHaveValue(unexpected)
				                   """);
		}
	}
}
