namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class HasValueTests
	{
		[Theory]
		[InlineData(MyNumbers.One, 2L)]
		[InlineData(MyNumbers.Two, -7)]
		[InlineData(MyNumbers.Three, 0)]
		public async Task WhenSubjectDoesNotHaveExpectedValue_ShouldFail(MyNumbers subject,
			long expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().HasValue(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   has value {expected},
				                   but found {subject}
				                   at Expect.That(subject).Should().HasValue(expected)
				                   """);
		}

		[Theory]
		[InlineData(MyNumbers.One, 1)]
		[InlineData(MyNumbers.Two, 2)]
		[InlineData(MyNumbers.Three, 3)]
		public async Task WhenSubjectHasExpectedValue_ShouldSucceed(MyNumbers subject, long expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().HasValue(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
