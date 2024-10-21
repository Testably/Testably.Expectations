#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateOnly
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenValuesAreDifferent_ShouldFail()
		{
			DateOnly value = CurrentTime();
			DateOnly expected = LaterTime();

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected:O},
				                   but found {value:O}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreTheSame_ShouldSucceed()
		{
			DateOnly value = CurrentTime();
			DateOnly expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
#endif
