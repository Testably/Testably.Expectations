namespace Testably.Expectations.Tests.That.Objects;

public sealed partial class ObjectShould
{
	public sealed class SatisfyTests
	{
		[Fact]
		public async Task WhenSatisfyConditionFails_ShouldIncludeTextInMessage()
		{
			Other subject = new() { Value = 1 };

			async Task Act()
				=> await Expect.That(subject).Should().Satisfy<Other, int>(o => o.Value, v => v.Be(2));

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  satisfy Value to be 2,
				                  but found 1
				                  at Expect.That(subject).Should().Satisfy<Other, int>(o => o.Value, v => v.Be(2))
				                  """);
		}
	}
}
