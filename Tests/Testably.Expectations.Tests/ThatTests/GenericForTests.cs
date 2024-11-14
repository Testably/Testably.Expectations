namespace Testably.Expectations.Tests.ThatTests;

public sealed class GenericForTests
{
	[Theory]
	[AutoData]
	public async Task WhenConditionIsNotSatisfied_ShouldFail(int value)
	{
		int expectedValue = value + 1;
		MyClass subject = new() { Value1 = value };

		async Task Act()
			=> await That(subject)
				.For(o => o.Value1, v => v.Should().Be(expectedValue));

		await That(Act).Should().Throw<XunitException>()
			.WithMessage($"""
			              Expected subject to
			              for .Value1 be {Formatter.Format(expectedValue)},
			              but found {Formatter.Format(value)}
			              """);
	}

	[Theory]
	[AutoData]
	public async Task WhenConditionIsSatisfied_ShouldSucceed(int value)
	{
		MyClass subject = new() { Value1 = value };

		async Task Act()
			=> await That(subject).For(o => o.Value1, v => v.Should().Be(value));

		await That(Act).Should().NotThrow();
	}

	private sealed class MyClass
	{
		public int Value1 { get; set; }
		public int Value2 { get; set; }
	}
}
