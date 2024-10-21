#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatTimeOnly
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenValuesAreTheSame_ShouldFail()
		{
			TimeOnly value = CurrentTime();
			TimeOnly unexpected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {unexpected:O},
				                   but found {value:O}
				                   at Expect.That(value).IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreDifferent_ShouldSucceed()
		{
			TimeOnly value = CurrentTime();
			TimeOnly unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(value).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
#endif
