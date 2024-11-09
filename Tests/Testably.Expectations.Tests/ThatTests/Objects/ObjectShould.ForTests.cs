namespace Testably.Expectations.Tests.ThatTests.Objects;

public sealed partial class ObjectShould
{
	public sealed class ForTests
	{
		[Theory]
		[AutoData]
		public async Task WhenConditionIsNotSatisfied_ShouldFail(int value)
		{
			int expectedValue = value + 1;
			MyClass subject = new() { Value = value };

			async Task Act()
				=> await That(subject).Should()
					.For<MyClass, int>(o => o.Value, v => v.Be(expectedValue));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              for .Value be {Formatter.Format(expectedValue)},
				              but found {Formatter.Format(value)}.
				              """);
		}

		[Theory]
		[AutoData]
		public async Task WhenConditionIsSatisfied_ShouldSucceed(int value)
		{
			MyClass subject = new() { Value = value };

			async Task Act()
				=> await That(subject).Should().For<MyClass, int>(o => o.Value, v => v.Be(value));

			await That(Act).Should().NotThrow();
		}
	}
}
