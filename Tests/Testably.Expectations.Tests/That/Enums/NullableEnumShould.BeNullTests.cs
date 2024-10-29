namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class NullableEnumShould
{
	public sealed class BeNullTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData((MyColors)42)]
		public async Task WhenSubjectIsNotNull_ShouldFail(MyColors? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be null,
				              but found {subject}
				              at Expect.That(subject).Should().BeNull()
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().BeNull();

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeNullTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData((MyColors)42)]
		public async Task WhenSubjectIsNotNull_ShouldSucceed(MyColors? subject)
		{
			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			MyColors? subject = null;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeNull();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be null,
				             but found <null>
				             at Expect.That(subject).Should().NotBeNull()
				             """);
		}
	}
}
