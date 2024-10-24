namespace Testably.Expectations.Tests.That.Objects;

public sealed partial class ThatObjectShould
{
	public sealed class BeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenTypeMatches_ShouldSucceed(int value)
		{
			object subject = new Other
			{
				Value = value
			};

			Other result = await Expect.That(subject).Should().Be<Other>();
			await Expect.That(result.Value).Should().Is(value);
		}
	}
}
