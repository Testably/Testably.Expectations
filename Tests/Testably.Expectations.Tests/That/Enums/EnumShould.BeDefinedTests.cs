namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class EnumShould
{
	public sealed class BeDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsDefined_ShouldSucceed(MyColors subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeDefined();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNotDefined_ShouldFail()
		{
			MyColors subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).Should().BeDefined();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                    Expected subject to
				                    be defined,
				                    but found {subject}
				                    at Expect.That(subject).Should().BeDefined()
				                    """);
		}
	}

	public sealed class NotBeDefinedTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsDefined_ShouldFail(MyColors subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeDefined();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                    Expected subject to
				                    not be defined,
				                    but found {subject}
				                    at Expect.That(subject).Should().NotBeDefined()
				                    """);
		}

		[Fact]
		public async Task WhenSubjectIsNotDefined_ShouldSucceed()
		{
			MyColors subject = (MyColors)42;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeDefined();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
