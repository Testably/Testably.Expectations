namespace Testably.Expectations.Tests.That;

public sealed partial class ThatGeneric
{
	public sealed class SatisfiesTests
	{
		[Fact]
		public async Task WhenSatisfyConditionFails_ShouldIncludeTextInMessage()
		{
			Other subject = new() { Value = 1 };

			async Task Act()
				=> await Expect.That(subject).Should().Satisfies<Other, int>(o => o.Value, v => v.Is(2));

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  satisfies Value is 2,
				                  but found 1
				                  at Expect.That(subject).Should().Satisfies<Other, int>(o => o.Value, v => v.Is(2))
				                  """);
		}
	}
}
