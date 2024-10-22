namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatNullableBool
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(true, false)]
		[InlineData(true, null)]
		[InlineData(false, true)]
		[InlineData(false, null)]
		[InlineData(null, true)]
		[InlineData(null, false)]
		public async Task WhenValuesAreDifferent_ShouldFail(bool? subject, bool? expected)
		{
			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected?.ToString() ?? "<null>"},
				                   but found {subject?.ToString() ?? "<null>"}
				                   at Expect.That(subject).Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		[InlineData(null)]
		public async Task WhenValuesAreTheSame_ShouldSucceed(bool? subject)
		{
			bool? expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
