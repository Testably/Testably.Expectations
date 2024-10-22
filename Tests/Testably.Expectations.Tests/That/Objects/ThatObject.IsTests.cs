namespace Testably.Expectations.Tests.That.Objects;

public sealed partial class ThatObject
{
	public sealed class IsTests
	{
		[Theory]
		[AutoData]
		public async Task WhenTypeMatches_ShouldSucceed(int value)
		{
			object subject = new Other
			{
				Value = value
			};

			Other result = await Expect.That(subject).Is<Other>();
			await Expect.That(result.Value).Is(value);
		}
	}
}
