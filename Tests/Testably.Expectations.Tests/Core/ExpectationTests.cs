namespace Testably.Expectations.Tests.Core;

public sealed class ExpectationTests
{
	[Theory]
	[InlineData(false, true)]
	[InlineData(true, false)]
	[InlineData(false, false)]
	public async Task And_ShouldFailWhenAnyArgumentFails(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Should().Is(a).And.Is(b);

		await Expect.That(Act).Should().ThrowsException();
	}

	[Theory]
	[InlineData(true, true)]
	public async Task And_ShouldRequireBothArgumentsToSucceed(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Should().Is(a).And.Is(b);

		await Expect.That(Act).Should().DoesNotThrow();
	}

	[Theory]
	[InlineData(false, false)]
	public async Task Or_ShouldFailWhenBothArgumentsFail(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Should().Is(a).Or.Is(b);

		await Expect.That(Act).Should().ThrowsException();
	}

	[Theory]
	[InlineData(false, true)]
	[InlineData(true, false)]
	[InlineData(true, true)]
	public async Task Or_ShouldRequireAnyArgumentToSucceed(bool a, bool b)
	{
		async Task Act()
			=> await Expect.That(true).Should().Is(a).Or.Is(b);

		await Expect.That(Act).Should().DoesNotThrow();
	}
}
