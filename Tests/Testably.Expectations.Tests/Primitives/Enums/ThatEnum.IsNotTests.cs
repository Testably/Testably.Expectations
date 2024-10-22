namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsNotTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValuesAreTheSame_ShouldFail(MyColors subject)
		{
			MyColors unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).IsNot(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		public async Task WhenValuesAreDifferent_ShouldSucceed(MyColors subject, MyColors unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
