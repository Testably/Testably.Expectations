namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	public sealed class BeTests
	{
		[Theory]
		[AutoData]
		public async Task WhenTypeMatches_ShouldSucceed(int value)
		{
			object subject = new Other { Value = value };

			Other result = await That(subject).Should().Be<Other>();
			await That(result.Value).Should().Be(value);
		}
	}
}
