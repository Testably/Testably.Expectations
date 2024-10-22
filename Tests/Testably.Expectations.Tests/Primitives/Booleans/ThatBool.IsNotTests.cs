namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsNotTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenValuesAreDifferent_ShouldSucceed(bool subject)
		{
			bool unexpected = !subject;

			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenValuesAreTheSame_ShouldFail(bool subject)
		{
			bool unexpected = subject;

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
	}
}
