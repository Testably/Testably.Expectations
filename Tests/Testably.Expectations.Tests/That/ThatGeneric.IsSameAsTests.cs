namespace Testably.Expectations.Tests.That;

public sealed partial class ThatGeneric
{
	public sealed class IsSameAsTests
	{
		[Fact]
		public async Task WhenComparingTheSameObjectReference_ShouldSucceed()
		{
			Other subject = new() { Value = 1 };
			Other expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsSameAs(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenComparingTwoIndividualObjectsWithSameValues_ShouldFail()
		{
			Other subject = new() { Value = 1 };
			Other expected = new() { Value = 1 };

			async Task Act()
				=> await Expect.That(subject).Should().IsSameAs(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  refers to expected Other{
				                    Value = 1
				                  },
				                  but found Other{
				                    Value = 1
				                  }
				                  at Expect.That(subject).Should().IsSameAs(expected)
				                  """);
		}
	}
}
